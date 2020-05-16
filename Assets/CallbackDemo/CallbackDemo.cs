using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallbackDemo : MonoBehaviour
{
	public	Text	text;

	IEnumerator DoEverySecond( int count, System.Action<int> action)
	{
		for (int i = 0; i < count; i++)
		{
			yield return new WaitForSeconds(1.0f);
			action(i);		// the callback
		}
	}

	void Start ()
	{
		StartCoroutine( DoEverySecond( 10, (result) =>
			{
				// result is the integer value passed back from the coroutine to this anonymous function
				// this adds an extra line to the existing text.
				text.text += "\nresult = " + result.ToString();
			}
		));
	}
}
