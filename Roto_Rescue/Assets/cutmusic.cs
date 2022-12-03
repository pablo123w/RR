using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutmusic : MonoBehaviour
{
    public AudioSource BGMusic;

    void Awake()
    {
        BGMusic = GameObject.Find("BACKGROUNDMUSIC").GetComponent<AudioSource>();
        BGMusic.enabled = false;
    }

}
