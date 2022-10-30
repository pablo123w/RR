using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTut : MonoBehaviour
{
	public GameObject ScoreArrow;

	public GameObject GoobTube;
	GoobTube GT;

	private void Start()
	{
		GT = GoobTube.GetComponent<GoobTube>();
	}
	
	public void ShowArrow()
	{
		ScoreArrow.SetActive(true);
	}

}
