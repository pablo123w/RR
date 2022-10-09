using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tellDamage : MonoBehaviour
{
	public GameObject DaddyGoob;
	goobScript GoobScript;

	public GameObject Player;

	private float HitImpact;

	public float GoobStrength = 0;
	public bool isGrabbed = false;

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
		if (other.gameObject.CompareTag("Player"))
		{
			Debug.Log("impact helo" + HitImpact);
			return;
		}


		//check if other is self
		if (other.transform.IsChildOf(DaddyGoob.transform) && isGrabbed == true)
		{
			Debug.Log("collided with itself");
			return;
		}
		if (other.transform.IsChildOf(Player.transform) && isGrabbed == true)
		{
			Debug.Log("collided with itself2");
			return;
		}
		DealDamage();
		//foreach (Transform transform in DaddyGoob.GetComponentsInChildren<Transform>())
		//{
		//	if (transform.root == other.transform.root)
		//	{
		//		Debug.Log("impact itself");

		//		HitImpact = 1000;
		//	}
		//	else
		//	{
		//		HitImpact = 0;
		//	}

		//}

		//if ((other.gameObject.name == "l_leg_jnt" && other.transform.root.gameObject != DaddyGoob) ||
		//	(other.gameObject.name == "l_foot_jnt" && other.transform.root.gameObject != DaddyGoob) ||
		//	(other.gameObject.name == "r_leg_jnt" && other.transform.root.gameObject != DaddyGoob) ||
		//	(other.gameObject.name == "r_foot_jnt" && other.transform.root.gameObject != DaddyGoob) ||
		//	(other.gameObject.name == "torso_jnt" && other.transform.root.gameObject != DaddyGoob) ||
		//	(other.gameObject.name == "head_jnt" && other.transform.root.gameObject != DaddyGoob) ||
		//	(other.gameObject.name == "l_shoulder_jnt" && other.transform.root.gameObject != DaddyGoob) ||
		//	(other.gameObject.name == "l_hand_jnt" && other.transform.root.gameObject != DaddyGoob) ||
		//	(other.gameObject.name == "r_shoulder_jnt" && other.transform.root.gameObject != DaddyGoob) ||
		//	(other.gameObject.name == "r_hand_jnt" && other.transform.root.gameObject != DaddyGoob)
		//	)




		//foreach (Transform transform in DaddyGoob.GetComponentsInChildren<Transform>())
		//{
		//	if (transform == other.transform)
		//	{
		//		Debug.Log("goober impacted with itself");
		//		return;
		//	}
		//}
	}

	void DealDamage()
	{
		if (HitImpact > GoobStrength)
		{
			GoobScript.TakeDamage(HitImpact);
		}
	}
}
