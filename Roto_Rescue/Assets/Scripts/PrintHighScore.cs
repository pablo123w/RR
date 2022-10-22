using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintHighScore : SaveScore
{
    public void Update()
    {

        PrintHigh();
    }
    public void PrintHigh()
    {
        highscore = PlayerPrefs.GetFloat("High Score");
        score.text = "HIGH SCORE: " + highscore;
    }
}
