using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breaksound : MonoBehaviour
{
    //sound for break
    public AudioSource BreakAS;
    public AudioClip[] Break;
    public AudioClip BreakClip;
    void Start()
    {
        //play sound
        int index = Random.Range(0, Break.Length);
        BreakClip = Break[index];
        BreakAS.clip = BreakClip;
        BreakAS.pitch = (Random.Range(0.5f, 1.5f));
        BreakAS.Play();
    }

    void Update()
    {
        
    }
}
