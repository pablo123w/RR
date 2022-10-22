using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	public float expForce, radius;
	public float objectStrength;
	public ParticleSystem explosion;


	private void OnCollisionEnter(Collision other)
	{
		if (other.relativeVelocity.magnitude > objectStrength)
		{
			//check if breakables, if so then break before exploding
			Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
			foreach (Collider nearby in colliders)
			{
				if (nearby.GetComponent<breakObject>() != null)
				{
					nearby.GetComponent<breakObject>().Break();

				}
			}

			Knockback();
			Destroy(gameObject);
		}
	}

	void Knockback()
	{
		Instantiate(explosion, this.transform.position, Quaternion.identity);
		Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

		foreach (Collider nearby in colliders)
		{
			Rigidbody rb = nearby.GetComponent<Rigidbody>();

			if (rb != null)
			{
				rb.AddExplosionForce(expForce, transform.position, radius);
				Debug.Log("add expl force");
			}
		}
	}
}

