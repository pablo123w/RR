using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlaylist : MonoBehaviour
{
    public AudioClip[] songs_list;
    int current = 0;

    void Update()
    {
        if (GetComponent<AudioSource>().isPlaying == false)
        {
            current++;
            if (current >= songs_list.Length)
            {
                current = 0;
                GetComponent<AudioSource>().clip = songs_list[current];
                GetComponent<AudioSource>().Play();
            }
        }
    }
}

