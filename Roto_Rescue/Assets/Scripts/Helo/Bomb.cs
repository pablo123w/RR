using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Splosive
{
	public override void OnCollide()
	{
		Explode();
	}
}
