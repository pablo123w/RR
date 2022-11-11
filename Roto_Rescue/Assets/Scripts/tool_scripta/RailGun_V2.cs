using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailGun_V2 : MonoBehaviour
{
    
    public GameObject Gbullet;
    public GameObject spawn;
    public float firerate;
    private float nextFireRate;
    public float speed = 1000f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f") )
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        // GameObject obj;
        nextFireRate = Time.time + firerate;
        GameObject newProjectile = Instantiate(Gbullet);
        newProjectile.transform.position = spawn.transform.position;
        newProjectile.transform.rotation = transform.rotation;
        // newProjectile.SetActive(true);
        newProjectile.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed, ForceMode.Force);
        Destroy(newProjectile, 5f);

    }
}
