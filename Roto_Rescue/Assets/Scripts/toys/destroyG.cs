using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyG : MonoBehaviour
{
	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "C_Goober")
		{
			Destroy(other.gameObject);
		}
	}
}
