using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReturnSpecificNumber : MonoBehaviour
{
	[SerializeField]
	private GameObject specificNumberParent;
	public void NumberFromTextElement()
	{
		var text = GetComponentInChildren<TextMeshProUGUI>();
		if (text.text.IsNumeric())
		{
			specificNumberParent.GetComponent<SelectedNumber>().SetNumber(int.Parse(text.text));
		}
	}
}
