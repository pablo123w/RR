using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ClawStart : MonoBehaviour
{
    public PlayerMain ply;
    public GameObject hook_point;
    public GameObject Rope;
    private GameObject goob;
    Rigidbody Rrgbd;
    //public breakObject cv;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("C_Goober"))
        {
            other.transform.parent = hook_point.transform;
            Rrgbd = other.GetComponent<Rigidbody>();
            //Rrgbd.freezeRotation = true;
            Rrgbd.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
            Rrgbd.isKinematic = true;

            //Destroy(other.gameObject);
        }

    }
    public void LetGoOfGoober(InputAction.CallbackContext contex)
    {
        goob = GameObject.FindWithTag("C_Goober");
        if (contex.performed)
        {
           
            if (goob.transform.IsChildOf(hook_point.gameObject.transform))
            {
            
            Rigidbody rg;
            rg = goob.GetComponent<Rigidbody>();
            // transform.SetParent(, true);
            goob.transform.SetParent(null, true);
            rg.useGravity = true;
            rg.isKinematic = false;
            Rrgbd.constraints = RigidbodyConstraints.FreezePositionZ;
            Rrgbd.constraints = RigidbodyConstraints.FreezePositionX;
            Rrgbd.constraints = RigidbodyConstraints.FreezePositionX;
            Rrgbd.constraints = RigidbodyConstraints.FreezePositionX;

            }
        }
        
       
    }
}
