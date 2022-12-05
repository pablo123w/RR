using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailGun_Bullet : Splosive
{
    public float speed = 10f;
    //public float radius = 5.0F;
    //public float power = 10.0F;
    public float lift = 30;
    //public float speed = 10;
    public bool explode = false;
    private bool IsSet = false;

    public GameObject Light;
    public Material RedLight;
    public Material GreenLight;
    public Material OrangeLight;

    private GameObject ThisBullet;

    public ParticleSystem Explosion;

    public AudioSource RailExplosion;

    // Start is called before the first frame update
    void Start()
    {
        ThisBullet = this.gameObject;
        RailExplosion = GameObject.Find("pla").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsSet == false)
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
        if (collision.gameObject.tag == "break_wall" || collision.gameObject.tag == "C_Goober" || collision.gameObject.tag == "Pickupable" || collision.gameObject.tag == "Destructible")

        {
			IsSet = true;
			StartCoroutine(TimedCharge(collision));
		}
	}

    public IEnumerator TimedCharge(Collision collision)
	{
        //stick to wall
        this.transform.parent = collision.gameObject.transform;
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<Collider>().enabled = false;

        //timer bullshit
		Light.GetComponent<MeshRenderer>().material = RedLight;
        yield return new WaitForSeconds(3f);

        //explode
        RailExplosion.Play();
        Explode();
        

		//Instantiate(Explosion, this.transform.position, Quaternion.identity);

		//Vector3 explosionPos = transform.position;
		//Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
		//foreach (Collider hit in colliders)
		//{
		//	if (hit.GetComponent<Rigidbody>())
		//	{
		//		hit.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, lift);
		//	}
		//}

        //stop existing as a bullet leave this fucking planet now go away i hate this bullet jesus fuck
        Destroy(ThisBullet);
	}

	public override void OnCollide()
	{
        return;
	}
}