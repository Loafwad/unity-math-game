using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCheckmark : MonoBehaviour
{
	private Transform checkmark;
	private bool toggle;

	private void Start()
	{
		checkmark = gameObject.transform.GetChild(1);
	}
	public void Toggle()
	{
		toggle = !toggle;
		if (toggle)
		{
			checkmark.gameObject.SetActive(true);
		}
		else
		{
			checkmark.gameObject.SetActive(false);
		}
	}
}
