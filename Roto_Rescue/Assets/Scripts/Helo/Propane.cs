using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ConstantForce))]
public class Propane : Splosive
{
	private ConstantForce Farter;

	public ParticleSystem[] Trail;
	private bool Farting;
	public Vector3 Power;
	public float Twist;

	public AudioSource Hiss;

	private void Start()
	{
		Farter = GetComponent<ConstantForce>();
	}
	public override void OnCollide()
	{
		if (Farting) return;
		Farting = true;
		StartCoroutine(Fart());
	}

	IEnumerator Fart()
	{
		// play sound
		Hiss.Play();

		//play particle systems
		for (int i = 0; i < Trail.Length; i++)
		{
			Trail[i].Play();
		}

		//blast off
		Farter.relativeForce = Power;

		//randomize direction
		for (int i = 0; i < 4; i++)
		{
			yield return new WaitForSeconds(1f);
			Farter.torque = new Vector3(0, 0, Random.Range(-Twist, Twist));
		}

		//boom
		Explode();
	}
}
