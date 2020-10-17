using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTransitionAnimation : MonoBehaviour
{
	[Header("Menu Rotation Animation")]
	public AnimationCurve animCurve;
	public float animDuration;
	public float animDelay;
	public void NextMenu(int rotation)
	{
		LeanTween.rotateZ(gameObject, gameObject.transform.position.z + rotation, animDuration).setDelay(animDelay).setEase(animCurve);
	}

}
