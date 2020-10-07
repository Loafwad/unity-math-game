using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumpadInput : MonoBehaviour
{
	[SerializeField]
	List<int> listOfNumbers = new List<int>();

	[SerializeField]
	TextMeshProUGUI numbers;
	int numbersAmount = 0;

	public void AddNumberToList(int number)
	{
		if(numbersAmount < 4)
		{
			listOfNumbers.Add(number);
			numbersAmount++;
			ListToText();
		}
	}

	public void ListToText()
	{
		numbers.text = string.Join("", listOfNumbers.ToArray());
	}

	public void ClearListAndText()
	{
		if(listOfNumbers.Count > 0)
		{
			listOfNumbers.RemoveAt(numbersAmount - 1);
			numbersAmount--;
			numbers.text = numbers.text.Remove(numbers.text.Length - 1);
		}
	}
}
