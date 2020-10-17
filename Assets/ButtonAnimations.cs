using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimations : MonoBehaviour
{
	//[Header("Hover Animation")]
	//public AnimationCurve animCurveHover;
	//public float animDurationHover = 1;
	//public float animDelayHover;

	[Header("Click Animation")]
	public AnimationCurve animCurveClick;
	public float animDurationClick = 1;

	[Header("Navigation Menus")]
	public GameObject currentMenu;
	public GameObject nextMenu;
	/*
	public void Hover(float size)
	{
		var scale = new Vector3(size, size, gameObject.transform.localScale.z);
		LeanTween.scale(gameObject, scale, animDurationHover).setDelay(animDelayHover).setLoopOnce().setEase(animCurveHover);
	}
	*/

	public void Click(float size)
	{
		var scale = new Vector3(size, size, gameObject.transform.localScale.z);
		LeanTween.scale(gameObject, scale, animDurationClick).setLoopOnce().setEase(animCurveClick).setOnComplete(Toggle);
	}

	private void Toggle()
	{
		gameObject.transform.localScale = new Vector3(1, 1, 1);
		//currentMenu.SetActive(false);
		//nextMenu.SetActive(true);
	}
}
