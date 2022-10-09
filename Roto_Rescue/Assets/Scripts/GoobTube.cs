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
            collectedhp = other.GetComponent<goobScript>().goobhp;
            if (collectedhp > 0)
			{

                LP.AddGoober(collectedhp);

                UpdateScoreText();
            }
            Destroy(other.transform.root.gameObject);
        }
    }
}
