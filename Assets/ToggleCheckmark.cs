using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCheckmark : MonoBehaviour
{
	private Transform checkmark;
	private bool toggle;

	private void Start()
	{
		checkmark = gameObject.transform.GetChild(2);
	}
	public void Toggle()
	{
		if (toggle)
		{
			checkmark.gameObject.SetActive(true);
			toggle = !toggle;
		}
		else
		{
			checkmark.gameObject.SetActive(false);
		}
	}
}
