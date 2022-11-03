using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tellDamage : MonoBehaviour
{
	public GameObject DaddyGoob;
	goobScript GoobScript;
	public float hpdivider = 0.5f;
	public float BloodMagnitude = 10;

	public GameObject Player;

	private float HitImpact;
	 
	public float GoobStrength = 0;
	public bool isGrabbed = false;

	//splat stuff
	public ParticleSystem[] Splat;


	private void Start()
	{
		GoobScript = DaddyGoob.GetComponent<goobScript>();
		Player = GameObject.Find("player_Claw");
	}

	private void OnCollisionEnter(Collision other)
	{
		HitImpact = other.relativeVelocity.magnitude;

		if (GoobScript == null) return;
		if (other == null) return;

		//check if other is player
		if (other.gameObject.CompareTag("Player") && isGrabbed)
		{
			Debug.Log("impact helo" + HitImpact);
			return;
		}


		//check if other is self
		if (other.gameObject.CompareTag("C_Goober") || other.gameObject.CompareTag("Goob_Part"))
		{
			if(isGrabbed == true)
			{
				Debug.Log("collided with itself");
				return;
			}
		}
		DealDamage();
	}

	void DealDamage()
	{
		if (HitImpact > GoobStrength)
		{
			//splat
			//Instantiate(Splat1, this.transform.position, Quaternion.identity);
			//Instantiate(Splat2, this.transform.position, Quaternion.identity);
			Debug.Log("goob impact is " + HitImpact);
			if (HitImpact > BloodMagnitude && GoobScript.goobhp > 0)
			{
				//for (int i = 0; i < Splat.Length; i++)
				//{
				//	Splat[i].Play();
				//}
			}

			//take damage
			GoobScript.TakeDamage((HitImpact*hpdivider));
		}
	}
}
