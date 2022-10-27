using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Priority : MonoBehaviour
{
    List<GameObject> collisions = new List<GameObject>();

    int collisionPriority = 0; // 0 Means it its everything
    int priority;
    float range = 2f;
    public GameObject Object1;
    public GameObject Object2;
    private void Start()
    {
        Object1 = GameObject.FindGameObjectWithTag("C_Goober");
        Object2 = GameObject.FindGameObjectWithTag("Pickupable");
    }
    private void Update()
    {
       
    }
    void OnCollisionEnter(Collision collision)
    {
        collisions.Add(collision.gameObject);
        SetCollisionPriority();
        if (Vector3.Distance(Object1.transform.position, Object2.transform.position) < range)
        {
            bool shouldIgnore = collision.gameObject.GetComponent<PrioritySys>().Priority < collisionPriority;
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.collider, shouldIgnore);
        }
        
    }

    //void OnCollisionLeave(Collision collision)
    //{
    //    collisions.Remove(collision.gameObject);
    //    SetCollisionPriority();
    //}

    void SetCollisionPriority()
    {
       

        foreach (GameObject obj in collisions)
        {
            
            var objPriority = obj.GetComponent<PrioritySys>().Priority;
            if (objPriority > priority)
                priority = objPriority;
        }

        collisionPriority = priority;
        Debug.Log("Collision: " + collisionPriority);
    }
}
