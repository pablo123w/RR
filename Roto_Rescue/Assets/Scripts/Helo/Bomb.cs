using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Splosive
{
	AudioSource Explode;
	public override void OnCollide()
	{
		Explode();
		//play sound
		Explode = GameObject.Find("Player_Final").GetComponent<AudioSource>();
		Explode.Play();
	}
}
