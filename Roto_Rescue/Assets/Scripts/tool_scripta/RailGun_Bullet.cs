using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailGun_Bullet : MonoBehaviour
{
    private float speed = 10f;
    public float radius = 5.0F;
    public float power = 10.0F;
    public float lift = 30;
    //public float speed = 10;
    public bool explode = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        if (explode)
        {
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                if (hit.GetComponent<Rigidbody>())
                {
                    hit.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, lift);
                }


            }
        }
    }
    public void Move()
    {
        Vector3 bulletSpeed = Vector3.right * speed;
        transform.Translate(bulletSpeed * Time.deltaTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goober")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "break_wall")
        {
            // Destroy(other.gameObject);
            explode = true;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "break_wall")
        {
            explode = true;
        }

    }
}