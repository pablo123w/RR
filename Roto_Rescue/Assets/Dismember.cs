using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dismember : MonoBehaviour
{
	private ConfigurableJoint CJ;
	private Rigidbody rb;
	public GameObject Limb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		CJ = GetComponent<ConfigurableJoint>();
	}

	private void OnJointBreak(float breakForce)
	{
		//if(transform.parent.gameObject.name == "clw")
		//{
		//	Debug.Log("being held by claw");
		//}
		Debug.Log("lol epic break joint!");
		//Destroy(rb);
		Destroy(GetComponent<BoxCollider>());
		GameObject NewLimb = Instantiate(Limb, this.transform, true);
		NewLimb.transform.SetParent(null);
		this.transform.localScale = Vector3.zero;
		this.transform.localPosition = Vector3.zero;

	}

}
