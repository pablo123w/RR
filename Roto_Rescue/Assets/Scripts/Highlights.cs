using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlights : MonoBehaviour
{
    private Color org;
    // Start is called before the first frame update
    void Start()
    {
        org = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "clw")
        {
            GetComponent<Renderer>().material.color = Color.red;
            Debug.Log("work");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GetComponent<Renderer>().material.color = org;
    }
}
