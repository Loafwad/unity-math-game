using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomMultiplication : MonoBehaviour
{
	[SerializeField]
	private int min, max;

	[SerializeField]
	private TextMeshProUGUI text;
	[SerializeField]
	private NumpadInput numpadInput;
	[SerializeField]
	private FeedbackText feedbackText;

	private int firstNumber;
	private int secondNumber;
	private void Start()
	{
		GenerateNewMathProblem();
	}

	public void GenerateNewMathProblem()
	{
		firstNumber = Random.Range(min, max);
		secondNumber = Random.Range(min, max);
		ParseToText();
		Debug.Log("Answer is " + Answer());
	}

	private int Answer()
	{
		return firstNumber * secondNumber;
	}

	//when anaswer has been submitted
	public void SubmitAnswer()
	{
		int numbers = numpadInput.AllNumbers();
		int amountOfNumbersInList = numpadInput.listOfNumbers.Count;
		if (AnswerIsSame(numbers))
		{
			Debug.Log("correct");
			FindObjectOfType<UniverseAnimation>().MakeNewPlanet();
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
		text.text = firstNumber.ToString() + " x " + secondNumber.ToString() + " =";
	}
}
