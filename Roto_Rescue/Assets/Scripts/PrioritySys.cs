using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PrioritySys : MonoBehaviour
{
    public int Priority;
    // Start is called before the first frame update
    void Start()
    {
        
    }
     
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "C_Goober")
        {
            Priority = 2;
            Debug.Log("P = " + Priority);
        }
        else if(other.gameObject.tag == "Pickupable")
        {
            Priority = 1;
            Debug.Log("P = " + Priority);
        }
    }

}
