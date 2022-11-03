using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseRTTrigger : MonoBehaviour
{
	public GameObject TutManager;
	ClawTut CT;
	private void Start()
	{
		CT = TutManager.GetComponent<ClawTut>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			CT.Release();
		}
	}
}

