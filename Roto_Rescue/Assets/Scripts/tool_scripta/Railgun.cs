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
    public float amp;
    public float freq;
    public float _shakeTimer;
    public float shakeLast;
    float speedRot = 1f;
    //public ParticleSystem rg;
    // Start is called before the first frame update
    void Awake()
    {
        //rg = GameObject.Find("RailGunSmoke").GetComponent<ParticleSystem>();
        gunPivot = GameObject.Find("gunPivot");
        gunEnd = GameObject.Find("gunEnd");
        _shakeTimer = shakeLast;
        rand = Random.value;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            shooting();
           
            //shshs();
            KickBack();
        }
        if (Input.GetKeyUp("f"))
        {
            //rg.Stop();
        }
       // Aim();
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
       shooting();
        KickBack();
    }
    public void aim(InputAction.CallbackContext context)
    {
        targetPosition = context.ReadValue<Vector2>();
        if (targetPosition.y < 0)
            gunPivot.transform.localRotation = Quaternion.FromToRotation(gunPivot.transform.position, targetPosition);
        else if (targetPosition.y > 0 && targetPosition.x < 0)
            gunPivot.transform.localRotation = Quaternion.FromToRotation(gunPivot.transform.position, Vector3.left);
        else if (targetPosition.y > 0 && targetPosition.x > 0)
            gunPivot.transform.localRotation = Quaternion.FromToRotation(gunPivot.transform.position, Vector3.right);
    }

}       
    

