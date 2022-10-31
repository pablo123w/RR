using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Objs : MonoBehaviour
{
    public GameObject objectToCreate;
    public GameObject shotSpawn;
    public float speed = 10f;
    public float interval = 5;
    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            GameObject bullet = Instantiate(objectToCreate);
            bullet.transform.position = shotSpawn.transform.position;
            bullet.GetComponent<Rigidbody>().AddForce(Vector3.down * speed, ForceMode.Force);
            Destroy(bullet, 10f);
            timer -= interval;
        }
    }
   
}
