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
    private bool IsSet = false;

    public GameObject Light;
    public Material RedLight;
    public Material GreenLight;
    public Material OrangeLight;

    public ParticleSystem Explosion;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(IsSet == false)
		{
            Move();
        }
        
    }
    public void Move()
    {
        Vector3 bulletSpeed = Vector3.forward * speed;
        transform.Translate(bulletSpeed * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "break_wall")
        {
            IsSet = true;
            StartCoroutine(TimedCharge());
        }
        if (collision.gameObject.tag == "C_Goober")
        {
            IsSet = true;
            StartCoroutine(TimedCharge());
        }
        if (collision.gameObject.tag == "Pickupable")
        {
            IsSet = true;
            StartCoroutine(TimedCharge());
        }
    }

    public IEnumerator TimedCharge()
	{
		//timer bullshit

		Light.GetComponent<MeshRenderer>().material = RedLight;
        yield return new WaitForSeconds(3f);

		//explode
		Instantiate(Explosion, this.transform.position, Quaternion.identity);

        //Vector3 explosionPos = transform.position;
        //Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        //foreach (Collider hit in colliders)
        //{
        //    if (hit.GetComponent<Rigidbody>())
        //    {
        //        hit.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, lift);
        //    }
        //}

        yield return null;
    }
}