using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying_Bird : MonoBehaviour
{
    public float speed;
    public bool isRight;
    public bool isLeft;
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
        }
        if (other.gameObject.tag == "Right")
        {
            isRight = true;
            isLeft = false;
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
