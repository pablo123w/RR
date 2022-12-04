using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Railgun : ToolBase_Guns
{
    Vector2 targetPosition;

    private Vector3 maxAngle = Vector3.one * 1;
    public GameObject gunPivot;
    public GameObject player;
    private GameObject gunEnd;
    public float rand;
    public AudioSource fg;
    
    public float amp;
    public float freq;
    public float _shakeTimer;
    public float shakeLast;
    float speedRot = 1f;
    //public ParticleSystem rg;

    //timer variables so the player can only shoot one at a time
    public float FireRate;
    private bool CanShoot = true;

    void Awake()
    {
        //rg = GameObject.Find("RailGunSmoke").GetComponent<ParticleSystem>();
        gunPivot = GameObject.Find("gunPivot");
        gunEnd = GameObject.Find("gunEnd");
        _shakeTimer = shakeLast;
        rand = Random.value;
       
    }
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            shooting();
            fg.Play();
            KickBack();
            StartCoroutine(WaitToShoot());

        }
        //if (Input.GetKeyUp("f"))
        //{
        //    //rg.Stop();
        //}
    }

    public void KickBack()
    {
        if (_shakeTimer > 0)
        {
            
          player.transform.localRotation = Quaternion.Euler(new Vector3(0,0, maxAngle.z * (Mathf.PerlinNoise(rand + 3, Time.time * amp) * freq)));

            
            _shakeTimer -= Time.deltaTime;
        }
        else
        {
            _shakeTimer = 0f;

        }
    }

   
   public void Fire(InputAction.CallbackContext context)
    {
		if (CanShoot)
		{
            shooting();
            fg.Play();
            KickBack();
            StartCoroutine(WaitToShoot());
        }
    }

	public IEnumerator WaitToShoot()
	{
        
        CanShoot = false;
        yield return new WaitForSeconds(1f);
        CanShoot = true;
	}

}       
    

