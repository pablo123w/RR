using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelProgression : MonoBehaviour
{
    public float GooberConstraint = 1f;
    public TextMeshProUGUI scoreUI;
    public float scorePercentUI;

    public float Score = 0;
    public float ScorePercent = 0;
    public float totalDeadGoober = 0f;
    
    goobScript gS;
    public GameObject[] Goober;

    public Image GooberConstraintImage;
    public Image GooberSavedImage;
    public GameObject NTLevel;
    public GameObject NextLevelButton;

    private GameObject[] TotalGoobers;
    float GoobCount = 0.0f;
    float TotalGoobHP;
    float TotalGoobHPMax;


    public void Start()
    {
        // NTLevel.SetActive(false);
        //GooberConstraintImage.fillAmount = GooberConstraint;
        //scoreUI = GetComponent<TextMeshProUGUI>();

        //get canvas to report health to UI
        Goober = GameObject.FindGameObjectsWithTag("C_Goober");
        //gS = Goober.GetComponent<goobScript>();

        // Tracks the amount of the goobers in the scene.
        TotalGoobers = GameObject.FindGameObjectsWithTag("C_Goober");
        GoobCount = TotalGoobers.Length;
        Debug.Log("goobcount is " + GoobCount);

        TotalGoobHPMax = GoobCount * 100;
        Debug.Log("total hp max: " + TotalGoobHPMax);
        TotalGoobHP = TotalGoobHPMax;
        Debug.Log("total goob HP at start: " + TotalGoobHP);
        
        //GooberConstraint = GoobCount / 10;
    }
    public void Update()
    {
        POPUPNT();
        scoreUI.text = scorePercentUI + "%";

        //LosePoint();

        
        //TESTING PURPOSES
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("K Was Pressed");
            LosePoint();     
            //GooberConstraint = GooberConstraint - 0.1f;
            GooberConstraint = GooberConstraint - 0.1f;
        }

        
    }
    public void LoseBlood(float impact)
    {
        TotalGoobHP -= impact;
        //Debug.Log("total goob hp after losing blood: " + TotalGoobHP);
        //GooberConstraint = TotalGoobHP / TotalGoobHPMax;
    }

    public void LosePoint()
    {
        GooberConstraint = GooberConstraint - totalDeadGoober;
        GooberConstraintImage.fillAmount = GooberConstraint;
        Debug.Log("Goober ALIVE ===================================== " + GooberConstraint);
        Debug.Log("Level Progression GooberConstraint gS.deadGoober " + gS.deadGoober);
        //GooberConstraint -= gS.deadGoober;
        //THIS SHOULD BE UPDATING THE LEVEL CONSTRAINT BAR BASED ON DEAD GOOBERS!
        //GooberConstraint = GooberConstraint - Score;
    }

    public void AddGoober()
    {
        Score ++;
        Debug.Log("score is: " + Score);
        //ScorePercent = (Score/100)/((TotalGoobHPMax)/100);
        ScorePercent = (Score) / (GoobCount);
        scorePercentUI = Score * 10;
        GooberSavedImage.fillAmount = ScorePercent;
	}
    public void NextLevel()
    {
        Debug.Log("pressed");
        Scene sn;
        sn = SceneManager.GetActiveScene();
        SceneManager.LoadScene(sn.buildIndex + 1);
    }
    public void RT()
    {
        Scene sn;
        sn = SceneManager.GetActiveScene();
        SceneManager.LoadScene(sn.buildIndex);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void POPUPNT()
    {
        if (ScorePercent > 0.5f)
        {
            Debug.Log("50% has been reached!");
            NTLevel.SetActive(true);
        }
    }
  
}
