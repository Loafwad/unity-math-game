using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCheckmark : MonoBehaviour
{
	[SerializeField]
	private string currentOption;
	private Transform checkmark;
	private bool toggle;

	private void Start()
	{
		checkmark = gameObject.transform.GetChild(1);
		LoadSettings();
	}
	public void Toggle()
	{
		toggle = !toggle;
		SaveSettings();
		if (toggle)
		{
			checkmark.gameObject.SetActive(true);
		}
		else
		{
			checkmark.gameObject.SetActive(false);
		}
	}
	
	public void SaveSettings()
	{
		PlayerPrefsX.SetBool(currentOption, toggle);
	}

	public void LoadSettings()
	{
		PlayerPrefsX.GetBool(currentOption);
	}
}

