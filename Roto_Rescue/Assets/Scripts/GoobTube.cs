using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoobTube : MonoBehaviour
{
    public float Score;
    public TMP_Text score_text;
    private float collectedhp;

    public GameObject Canvas;
    LevelProgression LP;

    public AudioSource GoobYay;

    void Start()
    {
        LP = Canvas.GetComponent<LevelProgression>();
        Score = 0;
        UpdateScoreText();

    }

    public void UpdateScoreText()
    {
        score_text.text = "Number of Goobers Saved: " + Score.ToString();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("C_Goober"))
        {
            //collectedhp = other.GetComponent<goobScript>().goobhp;
            if (other.GetComponent<goobScript>().goobhp > 0)
            {
                LP.AddGoober();
                UpdateScoreText();

                //play sfx
                GoobYay.pitch = (Random.Range(0.5f, 1.5f));
                GoobYay.Play();
            }
            
            
            Destroy(other.transform.gameObject);
        }
    }
}
