using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuTransitions : MonoBehaviour
{
	[System.Serializable]
	public class AnimateButton
	{
		[Header("Button Parameters")]
		public Vector2 newPosition;
		public AnimationCurve animCurve;
		public float animDuration;
		public float animDelay;

		public GameObject buttObject;
	}
	public List<AnimateButton> buttons = new List<AnimateButton>();

	private List<Vector3> originalPos = new List<Vector3>();

	private void Start()
	{
		if(gameObject.name != "StartMenu")
		{
			FirstTimeTransition();
		}
	}

	public void FirstTimeTransition()
	{
		for (int i = 0; i < buttons.Count; i++)
		{
			Vector2 objectPos = new Vector2(buttons[i].buttObject.transform.position.x, buttons
				[i].buttObject.transform.position.y);
			originalPos.Add(objectPos);

			Debug.Log(objectPos);
			LeanTween.move(buttons[i].buttObject, buttons[i].newPosition + objectPos, 0).setDelay(buttons[i].animDelay).setEase(buttons[i].animCurve);
		}
	}

	public void ExitTransition()
	{
		for (int i = 0; i < buttons.Count; i++)
		{
			Vector2 objectPos = new Vector2(buttons[i].buttObject.transform.position.x, buttons
				[i].buttObject.transform.position.y);
			originalPos.Add(objectPos);

			Debug.Log(objectPos);
			LeanTween.move(buttons[i].buttObject, buttons[i].newPosition + objectPos, buttons[i].animDuration).setDelay(buttons[i].animDelay).setEase(buttons[i].animCurve).setOnComplete(() => DisableObject(this.gameObject.transform.GetChild(0).gameObject));
		}
	}

	void DisableObject(GameObject objectToDisable)
	{
		objectToDisable.SetActive(false);
	}

	public void EnterTransition()
	{
		gameObject.transform.GetChild(0).gameObject.SetActive(true);
		for (int i = 0; i < buttons.Count; i++)
		{
			Vector2 objectPos = new Vector2(buttons[i].buttObject.transform.position.x, buttons
				[i].buttObject.transform.position.y);

			if(originalPos.Count > 0)
			{
				LeanTween.move(buttons[i].buttObject, originalPos[i], buttons[i].animDuration).setDelay(buttons[i].animDelay).setEase(buttons[i].animCurve);
			}
		}
	}

}



