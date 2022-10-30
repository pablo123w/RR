using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoobTrigger : MonoBehaviour
{
	public GameObject TutManager;
	public ClawTut CT;

	private void Start()
	{
		CT = TutManager.GetComponent<ClawTut>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			CT.PickUpPromptOn();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			CT.PickUpPromptOff();
		}
	}
}
