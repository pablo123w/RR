using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour
{
    public GameObject effect;
    private float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        effect.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {
        Vector3 bulletSpeed = Vector3.right * speed;
        transform.Translate(bulletSpeed * Time.deltaTime);
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Wall")
        {
           
            Rigidbody rg;
             rg = other.GetComponent<Rigidbody>();
            rg.AddForce(-10, 0, 0, ForceMode.Force);
            
        }
       
    }
}
