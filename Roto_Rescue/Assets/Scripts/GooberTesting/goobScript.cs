using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goobScript : MonoBehaviour
{
	public float goobhp = 100f;
	private float originGoobhp;
	public float deadGoober = 0f;
	public bool isDead = false;
	public float impact;
	public int deathNote = 0;
	//color change stuff
	public GameObject daddyGoob;
	public GameObject goobBody;
	public Mesh goobMesh;
	private Renderer rend;
	private Material mat;
	private float redVal = 0;
	private float greenVal = 0f;
	private float blueVal = 0f;

	//report values to canvas
	public GameObject Canvas;
	LevelProgression LP;

	//grabbed

	public bool IsGrabbed;

	//shaking

	private Transform transformG;
	public float shakeDuration;
	public float shakeMagnitude;
	private float dampingSpeed = 1.0f;
	Vector3 initialPosition;

	//sound for grab
	public AudioSource GrabGoober;

	//sounds for hurt
	public AudioSource HurtAS;
	public AudioClip[] Hurt;
	public AudioClip HurtClip;

	//sounds for death
	public AudioSource DeathAS;
	public AudioClip[] Death;
	public AudioClip DeathClip;

	void Start()
	{
		//set goober gameobject
		daddyGoob = this.gameObject;

		//remember start goober hp, just in case we change the hp
		originGoobhp = goobhp;

		//get the material of goober to change
		mat = goobBody.GetComponent<Renderer>().material;

		//get canvas to report health to UI
		Canvas = GameObject.Find("Canvas");
		LP = Canvas.GetComponent<LevelProgression>();

		//if (transformG == null)
		//{
		//	transformG = GetComponent(typeof(Transform)) as Transform;
		//}
		initialPosition = transform.localPosition;
	}

	void Update()
	{
		if (goobhp <= 0 && isDead == false)
		{
			isDead = true;
			death();
			Debug.Log("[goobScript] Dead Goober Function Triggered");
			GooberDead();
			
        }
		ShakeGoob();
	}

	public void GooberDead()
	{
		if (goobhp <= 0)
		{
			deadGoober = deadGoober + 0.1f;
            LP.totalDeadGoober = 0.1f;
            LP.LosePoint();
			//deathNote += 1;
			Debug.Log("[goobScript] Goober is dead. NOTICE ME SENPAI");
			Debug.Log("[goobScript] DEAD GOOBER VARIABLE = " + deadGoober);
			Destroy(gameObject);
		}
		//deadGoober = deadGoober - 0.1f;
	}

	public void death()
	{
		if (isDead)
		{
			//play sound
			int index = Random.Range(0, Death.Length);
			DeathClip = Death[index];
			DeathAS.clip = HurtClip;
			DeathAS.pitch = (Random.Range(0.5f, 1.5f));
			DeathAS.Play();

			mat.color = new Color(0.13f, 0f, 0.98f);
			//deathNote++;
			//gameObject.tag = "Pickupable";
		}
	}


	public void TakeDamage(float impact)
	{
		if (goobhp > 0)
		{
			goobhp -= impact;
			HealthConversion();
			//Debug.Log(this.name + " HEALTH: " + goobhp);
			LP.LoseBlood(impact);

			//play sound
			int index = Random.Range(0, Hurt.Length);
			HurtClip = Hurt[index];
			HurtAS.clip = HurtClip;
			HurtAS.pitch = (Random.Range(0.5f, 1.5f));
			HurtAS.Play();
		}
	}
	private void HealthConversion()
	{
		//red
		redVal = (Mathf.Round(((150 + ((goobhp / 100f) * 100f))/255) * 100)) / 100;
		//green
		greenVal = (Mathf.Round(((150 + ((goobhp / 100f) * 59f))/255) * 100)) / 100;
		//blue addition
		blueVal = (Mathf.Round(((Mathf.Abs(((goobhp / 100f) * 150f) - 150))/255) * 100)) / 100;
		mat.color = new Color(redVal, greenVal, blueVal);
	}

	public void TellGrabbed()
	{
		
		foreach (Transform transform in this.GetComponentsInChildren<Transform>())
		{
			if(transform.GetComponent<tellDamage>() != null)
			{
				transform.GetComponent<tellDamage>().isGrabbed = true;
				Debug.Log("is grabbed = " + transform.GetComponent<tellDamage>().isGrabbed);
			}
		}
		if (!isDead)
		{
			GrabGoober.pitch = (Random.Range(0.5f, 1.5f));
			GrabGoober.Play();
		}

	}

	public void TellNotGrabbed()
	{
		foreach (Transform transform in this.GetComponentsInChildren<Transform>())
		{
			if (transform.GetComponent<tellDamage>() != null)
			{
				transform.GetComponent<tellDamage>().isGrabbed = false;
			}
		}
	}
	public void ShakeGoob()
    {
		Rigidbody rg;
		rg = GetComponent<Rigidbody>();
        if (goobhp < 20)
        {
            if (shakeDuration > 0)
            {

                transform.localPosition = this.transform.position + Random.insideUnitSphere * shakeMagnitude;
				
                shakeDuration -= Time.deltaTime * dampingSpeed;
            }
            else
            {
                shakeDuration = 0f;
				
				
                //transform.localPosition = this.transform.position;
            }

        }
    }
}
