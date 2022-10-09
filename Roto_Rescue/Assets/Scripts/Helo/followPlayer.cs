using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform player;
    public float smooth;
    private Vector3 bPos;
    private Vector3 cPos;
    private Vector3 camOffset = new Vector3(0, -2, -15);
    private void Start()
    {
        bPos = transform.position - player.position;
    }
    void FixedUpdate()
    {
        
        camMove();
    }
    public void camMove()
    {
        cPos = transform.position;
        transform.position = Vector3.Lerp(transform.position, cPos, smooth * Time.fixedDeltaTime);
        transform.position = player.transform.position + camOffset;
    }
}
