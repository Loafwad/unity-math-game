using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeedbackText : MonoBehaviour
{
	[SerializeField]
	private float correctFadeTime = 0.5f;
	[SerializeField]
	private TextMeshProUGUI correct;

	[SerializeField]
	private float wrongFadeTime = 0.5f;
	[SerializeField]
	private TextMeshProUGUI wrong;

	bool toggle;
    public void ToggleCorrect()
	{
		toggle = !toggle;
		correct.gameObject.SetActive(toggle);
		StartCoroutine(FadeTextToZeroAlpha(correctFadeTime, correct));
		toggle = !toggle;
	}

	public void ToggleWrong()
	{
		toggle = !toggle;
		wrong.gameObject.SetActive(toggle);
		StartCoroutine(FadeTextToZeroAlpha(wrongFadeTime, wrong));
		toggle = !toggle;
	}

	public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI i)
	{
		i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
		while (i.color.a < 1.0f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
			yield return null;
		}
	}

	public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
	{
		i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
		while (i.color.a > 0.0f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
			yield return null;
		}
	}

	public void DisableBoth()
	{
		correct.gameObject.SetActive(false);
		wrong.gameObject.SetActive(false);
	}

}
