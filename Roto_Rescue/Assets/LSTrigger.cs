using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSTrigger : MonoBehaviour
{
	public GameObject TutManager;
	ClawTut CT;
	private void Start()
	{
		CT = TutManager.GetComponent<ClawTut>();
	}

	private void OnTriggerExit(Collider other)
	{
		Debug.Log("exited");
		if (other.CompareTag("Player"))
		{
			CT.TurnOffLSPrompt();
		}
	}
}
