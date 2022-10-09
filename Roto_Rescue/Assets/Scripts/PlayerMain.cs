using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class PlayerMain : MonoBehaviour
{
    public int Health = 100;
    public TMP_Text health_text;

    // Update is called once per frame
    void Update()
    {
        Respawn();
    }

    public void UpdateHealthText()
    {
        health_text.text = "Health: " + Health.ToString();
    }
    public void OnColliderEnter(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            Health -= 20;
            UpdateHealthText();
        }
        if (other.CompareTag("Floor"))
        {
            Health -= 50;
            UpdateHealthText();
        }
        if (other.CompareTag("Obstacle"))
        {
            Health -= 50;
            UpdateHealthText();
        }
        //if (other.CompareTag("Wall"))
        //{
        //    Health -= 5;
        //    UpdateHealthText();
        //}
        //if (other.CompareTag("Goober"))
        //{
        //    Score += 1;
        //    UpdateScoreText();
        //}
    }
    private void Respawn()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(Health == 0)
        {
            SceneManager.LoadScene(scene.buildIndex);
        }
    }

}
