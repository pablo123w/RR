using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flying_Bird : MonoBehaviour
{
    public float speed;
    public bool isRight;
    public bool isLeft;
    private SpriteRenderer sp;
    public GameObject gmOver;
    public void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }
    public void Update()
    {
        Move();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Left")
        {
            isLeft = true;
            isRight = false;
            sp.flipX = false;
        }
        if (other.gameObject.tag == "Right")
        {
            isRight = true;
            isLeft = false;
            sp.flipX = true;
        }
        if(other.gameObject.tag == "Player")
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gmOver.SetActive(true);
            Rigidbody rg;
            rg = other.GetComponent<Rigidbody>();
            rg.constraints = RigidbodyConstraints.FreezeAll;
           
         
           Debug.Log("Light Yagami Almost Became a God");
        }
        if(other.gameObject.tag == "RGBullet")
        {
            Destroy(gameObject);
        }
    }
    public void Move()
    {
        if (isLeft)
        {
            
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (isRight)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
