using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTutTrigger : MonoBehaviour
{
	public GameObject TutManager;
	ScoreTut ST;

	private void Start()
	{
		ST = TutManager.GetComponent<ScoreTut>(); 
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("C_Goober"))
		{
			ST.ShowArrow();
			Destroy(this);
		}
	}
}
