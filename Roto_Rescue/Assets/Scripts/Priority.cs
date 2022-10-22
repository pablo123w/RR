using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priority : MonoBehaviour
{
    List<GameObject> collisions = new List<GameObject>();

    int collisionPriority = 0; // 0 Means it its everything
    int priority;
    private void Update()
    {
       
    }
    void OnCollisionEnter(Collision collision)
    {
        collisions.Add(collision.gameObject);
        SetCollisionPriority();
         
        bool shouldIgnore = collision.gameObject.GetComponent<PrioritySys>().Priority < collisionPriority;
        Physics.IgnoreCollision(GetComponent<Collider>(), collision.collider, shouldIgnore);
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
