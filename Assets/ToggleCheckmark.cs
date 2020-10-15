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

//move to seperate script
public class PlayerPrefsX
{
	public static void SetBool(string name, bool booleanValue)
	{
		PlayerPrefs.SetInt(name, booleanValue ? 1 : 0);
	}

	public static bool GetBool(string name)
	{
		return PlayerPrefs.GetInt(name) == 1 ? true : false;
	}

	public static bool GetBool(string name, bool defaultValue)
	{
		if (PlayerPrefs.HasKey(name))
		{
			return GetBool(name);
		}

		return defaultValue;
	}
}