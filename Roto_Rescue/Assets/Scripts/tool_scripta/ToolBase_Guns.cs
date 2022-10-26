using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToolBase_Guns : MonoBehaviour
{
    public GameObject shot;
    public float shotSpeed = 1;
    public GameObject shotSpawn;
     

    public void shooting()
    {
        GameObject bullet = (GameObject)Instantiate(shot);
        bullet.transform.position = shotSpawn.transform.position;
       
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * shotSpeed;
        
        Destroy(bullet, 5f);
    }
    public void shshs()
    {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = (Vector3)((worldMousePos - transform.position));
        direction.Normalize();

        // Creates the bullet locally
        GameObject bullet = (GameObject)Instantiate(shot,transform.position + (Vector3)(direction * .5f),Quaternion.identity);

        // Adds velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = direction * shotSpeed;
    }
   
}
