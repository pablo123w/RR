using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RopeLength : MonoBehaviour
{
    public Rigidbody rg;
    //private Rigidbody dg;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeLength(InputAction.CallbackContext context)
    {
       // Rrgbd = Rope.GetComponent<Rigidbody>();
        //Rrgbd.freezeRotation = true;
        rg.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
        rg.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
        
       // transform.localPosition += new Vector3(0, -.05f, 0);
    }
    public void MinusLength(InputAction.CallbackContext context)
    {

        rg.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
        rg.transform.localScale += new Vector3(0f, -.05f, 0f);
           // transform.localPosition += new Vector3(0, .05f, 0);
        
       
    }
}
