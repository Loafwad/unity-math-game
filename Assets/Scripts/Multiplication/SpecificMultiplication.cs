using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpecificMultiplication : MonoBehaviour
{
	[SerializeField]
	private int min, max;

	[SerializeField]
	private TextMeshProUGUI text;
	[SerializeField]
	private NumpadInput numpadInput;
	[SerializeField]
	private FeedbackText feedbackText;
	[SerializeField]
	private GameObject specificMulti;

	private int selectedNumber;
	private int secondNumber;

	private void Start()
	{
		GetSelectedNumber();
		GenerateNewMathProblem();
	}

	public void GetSelectedNumber()
	{
		selectedNumber = specificMulti.GetComponent<SelectedNumber>().GetNumber();

	}

	public void GenerateNewMathProblem()
	{
		secondNumber = Random.Range(min, max);
		Debug.Log("selected number is " + selectedNumber);
		ParseToText();
		Debug.Log("Answer is " + Answer());
	}

	private int Answer()
	{
		return selectedNumber * secondNumber;
	}

	//when anaswer has been submitted
	public void SubmitAnswer()
	{
		int numbers = numpadInput.AllNumbers();
		int amountOfNumbersInList = numpadInput.listOfNumbers.Count;
		if (AnswerIsSame(numbers))
		{
			Debug.Log("correct");
			//FindObjectOfType<UniverseAnimation>().MakeNewPlanet();
			for (int i = 0; i < amountOfNumbersInList; i++)
			{
				numpadInput.RemoveLastNumber();
			}
			GenerateNewMathProblem();
			feedbackText.ToggleCorrect();
		}
		else
		{
			Debug.Log("wrong");
			for (int i = 0; i < amountOfNumbersInList; i++)
			{
				numpadInput.RemoveLastNumber();
			}
			feedbackText.ToggleWrong();
		}
	}
	private bool AnswerIsSame(int answer)
	{
		if(answer == Answer())
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	private void ParseToText()
	{
		text.text = selectedNumber.ToString() + " x " + secondNumber.ToString() + " =";
	}
}
