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
                //shshs();
                KickBack();
            fg.Play();
            StartCoroutine(WaitToShoot());
           
        }
        if (Input.GetKeyUp("f"))
        {
            //rg.Stop();
        }
        //Aim();
    }
    
  //public void Aim()
  //{
  //      transform.LookAt(speedRot * new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2, 0));
  //}
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
            KickBack();
            StartCoroutine(WaitToShoot());
        }
    }
    public void aim(InputAction.CallbackContext context)
    {
        
        //targetPosition = context.ReadValue<Vector2>();

        //gunPivot.transform.rotation = Quaternion.Euler(0, 0, targetPosition.x * 90 + targetPosition.y * 90);


        //if (targetPosition.y < 0)
        //    gunPivot.transform.rotation = Quaternion.FromToRotation(gunPivot.transform.position, targetPosition);
        //else if (targetPosition.y > 0 && targetPosition.x < 0)
        //    gunPivot.transform.rotation = Quaternion.FromToRotation(gunPivot.transform.position, Vector3.left);
        //else if (targetPosition.y > 0 && targetPosition.x > 0)
        //    gunPivot.transform.rotation = Quaternion.FromToRotation(gunPivot.transform.position, Vector3.right);
    }

	public IEnumerator WaitToShoot()
	{
        CanShoot = false;
        yield return new WaitForSeconds(1f);
        CanShoot = true;
	}

}       
    

