using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterIn : MonoBehaviour
{
	public GameObject tpm;
	Teleporter Teleporter;

	private void Start()
	{
		Teleporter = tpm.GetComponent<Teleporter>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "prop")
		{
			Teleporter.PropGoIn();
			Destroy(other.gameObject);
		}
	}

}
