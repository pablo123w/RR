using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoreSetting : MonoBehaviour
{

    public static bool goreAllowed = false;
    public GameObject Gore;
    // Start is called before the first frame update
    void Awake()
    {
        Object.DontDestroyOnLoad(Gore);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GoreAllowed()
    {
        goreAllowed = true;
    }
    public void NoGore()
    {
        goreAllowed = false;
    }
}
