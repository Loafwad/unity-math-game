using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReturnNumber : MonoBehaviour
{
    public void NumberFromTextElement()
	{
		var text = GetComponentInChildren<TextMeshProUGUI>();
		if (text.text.IsNumeric())
		{
			this.transform.parent.parent.GetComponent<NumpadInput>().AddNumberToList(int.Parse(text.text));
		}
	}
}
