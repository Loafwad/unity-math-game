using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedNumber : MonoBehaviour
{
	public int selectedNumber;

	public void SetNumber(int number)
	{
		selectedNumber = number;
	}

	public int GetNumber()
	{
		return selectedNumber;
	}
}
