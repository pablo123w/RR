using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicshuffle : MonoBehaviour
{
    public AudioSource SongAS;
    public AudioClip[] Song;
    public AudioClip SongClip;
    // Start is called before the first frame update
    void Start()
    {
        //play sound
        int index = Random.Range(0, Song.Length);
        SongClip = Song[index];
        SongAS.clip = SongClip;
        SongAS.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
