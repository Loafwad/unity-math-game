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
	public bool isEntering;
	public bool isExiting;

	LTDescr ExitTween;
	LTDescr EnterTween;

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
			Vector2 result = buttons[i].buttObject.transform.position;
			result = buttons[i].newPosition * new Vector2(Mathf.Abs(Screen.width / 100), Mathf.Abs(Screen.height / 100));
			if (buttons[i].newPosition.y == 0)
			{
				result.y = buttons[i].buttObject.transform.position.y;
			}
			if (buttons[i].newPosition.x == 0)
			{
				result.x = buttons[i].buttObject.transform.position.x;
			}

			LeanTween.move(buttons[i].buttObject, result, 0).setDelay(buttons[i].animDelay).setEase(buttons[i].animCurve);
		}
	}

	private void Update()
	{
		if(isExiting || isEntering)
		{
			foreach (Button child in Resources.FindObjectsOfTypeAll(typeof(Button)) as Button[])
			{
				child.interactable = false;
			}
		}
		else
		{
			foreach (Button child in Resources.FindObjectsOfTypeAll(typeof(Button)) as Button[])
			{
				child.interactable = true;
			}
		}
	}

	public void ExitTransition()
	{
		Debug.Log("called Exit");
		if (!isEntering && !isExiting)
		{
			isExiting = true;
			Debug.Log("started");
			for (int i = 0; i < buttons.Count; i++)
			{
				Vector2 objectPos = new Vector2(buttons[i].buttObject.transform.position.x, buttons
				[i].buttObject.transform.position.y);
				originalPos.Add(objectPos);
				Vector2 result = buttons[i].buttObject.transform.position;
				result = buttons[i].newPosition * new Vector2(Mathf.Abs(Screen.width / 100), Mathf.Abs(Screen.height / 100));
				if (buttons[i].newPosition.y == 0)
				{
					result.y = buttons[i].buttObject.transform.position.y;
				}
				if (buttons[i].newPosition.x == 0)
				{
					result.x = buttons[i].buttObject.transform.position.x;
				}

				ExitTween = LeanTween.move(buttons[i].buttObject, result, buttons[i].animDuration).setDelay(buttons[i].animDelay).setEase(buttons[i].animCurve).setOnComplete(FinishedExiting);
			}
		}
	}

	void FinishedExiting()
	{
		this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
		isExiting = false;
	}

	public void EnterTransition()
	{
		Debug.Log("called Enter");
		if (!isExiting && !isEntering)
		{
			isEntering = true;
			this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
			for (int i = 0; i < buttons.Count; i++)
			{
				if (originalPos.Count > 0)
				{
					EnterTween = LeanTween.move(buttons[i].buttObject, originalPos[i], buttons[i].animDuration).setDelay(buttons[i].animDelay).setEase(buttons[i].animCurve).setOnComplete(FinishedEntering);
				}
			}
		}
	}
	void FinishedEntering()
	{
		isEntering = false;
	}
}



