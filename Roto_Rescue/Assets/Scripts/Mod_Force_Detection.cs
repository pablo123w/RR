using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mod_Force_Detection : MonoBehaviour
{
    public Rigidbody rg;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        rg.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > force)
        {
            rg.isKinematic = false;
        }
    }
}
