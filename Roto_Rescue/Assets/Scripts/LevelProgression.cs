using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelProgression : MonoBehaviour
{
    public float GooberConstraint = 1;

    public float Score = 0;
    public float ScorePercent = 0;

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
        GooberConstraintImage.fillAmount = GooberConstraint;

        // Tracks the amount of the goobers in the scene.
        TotalGoobers = GameObject.FindGameObjectsWithTag("C_Goober");

        GoobCount = TotalGoobers.Length;
        Debug.Log("goobcount is " + GoobCount);

        TotalGoobHPMax = GoobCount * 100;
        Debug.Log("total hp max: " + TotalGoobHPMax);
        TotalGoobHP = TotalGoobHPMax;
        Debug.Log("total goob HP at start: " + TotalGoobHP);
    }
    public void Update()
    {
        POPUPNT();
    }
    public void LoseBlood(float impact)
    {
        TotalGoobHP -= impact;
        Debug.Log("total goob hp after losing blood: " + TotalGoobHP);
        GooberConstraint = TotalGoobHP / TotalGoobHPMax;
        Debug.Log("goober constraint: " + GooberConstraint);

        GooberConstraintImage.fillAmount = GooberConstraint;
    }
    public void AddGoober(float collectedhp)
    {
        Score += collectedhp;
        Debug.Log("score is: " + Score);
        ScorePercent = (Score/100)/((TotalGoobHPMax)/100);
        Debug.Log("added " + collectedhp);
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
