using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public abstract class Splosive : MonoBehaviour
{
	public float expForce, radius;
	public float objectStrength;
	public ParticleSystem explosion;

	public void Explode()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
		foreach (Collider nearby in colliders)
		{
			if (nearby.GetComponent<breakObject>() != null)
			{
				nearby.GetComponent<breakObject>().Break();
			}
			if(nearby.tag == ("C_Goober"))
			{
				nearby.GetComponent<goobScript>().TakeDamage(15);
			}
		}
		Knockback();
		Destroy(gameObject);
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.relativeVelocity.magnitude > objectStrength)
		{
			OnCollide();
		}
	}
	public abstract void OnCollide();
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

