using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringExt
{
	public static bool IsNumeric(this string text) => double.TryParse(text, out _);
}
