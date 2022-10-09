using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harpoonScript : MonoBehaviour
{
	Rigidbody rb = null;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.isKinematic = false;
	}
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.GetComponent<Rigidbody>() != null && !collision.gameObject.CompareTag("Player"))
		{
			rb.velocity = Vector3.zero;
			rb.isKinematic = true;

			gameObject.AddComponent<FixedJoint>();
			gameObject.GetComponent<FixedJoint>().connectedBody = collision.rigidbody;
		}
	}
}
