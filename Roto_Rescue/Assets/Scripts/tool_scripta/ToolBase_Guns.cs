using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToolBase_Guns : MonoBehaviour
{
    public GameObject Projectile;
    public float shotSpeed = 1;
    public GameObject shotSpawn;
     

    public void shooting()
    {
            Debug.Log("shooting");

            GameObject bullet = Instantiate(Projectile);
            bullet.transform.position = shotSpawn.transform.position;

            //bullet.GetComponent<Rigidbody>().velocity = transform.forward * shotSpeed;

            if (bullet != null)
            {
                Destroy(bullet, 10f);
            }
        
    }
   
}
