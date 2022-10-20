using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	public float expForce, radius;
	public float objectStrength;

	private breakObject breakObj;


	private void OnCollisionEnter(Collision other)
	{
		if (other.relativeVelocity.magnitude > objectStrength)
		{
			//RaycastHit hit;
			//get all destructibles
			//if(Physics.SphereCast(transform.position, 10f, transform.forward, out hit, 10))


			breakObj.Break();
			Debug.Log("break destructibles");
			Knockback();
			Destroy(gameObject);
		}
	}

	void Knockback()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

		foreach (Collider nearby in colliders)
		{
			Rigidbody rb = nearby.GetComponent<Rigidbody>();
			Debug.Log("get rb");

			if (rb != null)
			{
				rb.AddExplosionForce(expForce, transform.position, radius);
				Debug.Log("add expl force");
			}
		}
	}
}

