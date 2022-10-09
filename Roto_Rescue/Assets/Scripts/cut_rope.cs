using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cut_rope : MonoBehaviour
{
    public GameObject rope_1;
    public GameObject rope_2;
    public GameObject Obstacle;
    public GameObject spawn_1;
    public GameObject spawn_2;
    Rigidbody Rrgbd;
    // Start is called before the first frame update
    void Start()
    {
        Obstacle = GameObject.FindWithTag("Obstacle");
        Rrgbd = Obstacle.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject rp1 = (GameObject)Instantiate(rope_1);
            rp1.transform.position = spawn_1.transform.position;
            GameObject rp2 = (GameObject)Instantiate(rope_2);
            rp2.transform.position = spawn_1.transform.position;
            Rrgbd.isKinematic = false;
            Rrgbd.useGravity = true;
            if (Obstacle.transform.IsChildOf(gameObject.transform))
            {
                Obstacle.transform.SetParent(null, true);
            }
                

            Destroy(gameObject);
        }
    }
}
