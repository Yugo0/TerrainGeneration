using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueLabelController : MonoBehaviour
{
	private Text text;

	void Start()
	{
		text = GetComponent<Text>();
	}

	public void setValue(float value)
	{
		text.text = value.ToString();
	}
}
