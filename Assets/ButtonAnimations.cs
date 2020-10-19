using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimations : MonoBehaviour
{
	[Header("Click Animation")]
	public AnimationCurve animCurveClick;
	public float animDurationClick = 1;

	[Header("Slider Animation")]
	public AnimationCurve animCurveSlide;
	public float animDurationSlide = 1;


	public void Click(float size)
	{
		var scale = new Vector3(size, size, gameObject.transform.localScale.z);
		LeanTween.scale(gameObject, scale, animDurationClick).setLoopOnce().setEase(animCurveClick).setOnComplete(Toggle);
	}

	private void Toggle()
	{
		gameObject.transform.localScale = new Vector3(1, 1, 1);
	}

	public void Slide()
	{
		this.gameObject.SetActive(true);
		this.gameObject.transform.position = new Vector3(-500, gameObject.transform.position.y, gameObject.transform.position.z);
		LeanTween.moveX(this.gameObject, 1000, animDurationSlide);
	}
}
