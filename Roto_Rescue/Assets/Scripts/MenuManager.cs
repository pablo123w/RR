using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject mainMenuUI;
    public GameObject pauseMenuUI;
    public GameObject levelSelectUI;
    public int level;
   // public bool goreAllowed = false;
    public void Start()
    {
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }
    public void ctrlMenu(InputAction.CallbackContext context)
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
   
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Resume()
    {
        Debug.Log("Resuming Game!");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        Debug.Log("Game Paused!");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game!");
        Application.Quit();
    }

    public void LevelSelectScreen()
    {
        if (level == 0)
        {
            Debug.Log("Level Select Screen from Start Menu");
            mainMenuUI.SetActive(false);
            levelSelectUI.SetActive(true);
        }
        else
        {
            Debug.Log("Level Select from a level");
            SceneManager.LoadScene(0);
            mainMenuUI.SetActive(false);
            levelSelectUI.SetActive(true);
        }
    }
    public void Lem()
    {
        SceneManager.LoadScene("LevelsMenu");
    }
    public void MainMenuScreen()
    {
        if (level == 0)
        {
            Debug.Log("BACK TO MAIN MENU SCREEN!");
            levelSelectUI.SetActive(false);
            mainMenuUI.SetActive(true);
        }
        else
        {
            Debug.Log("Back to Main Menu from level");
            SceneManager.LoadScene(0);
        }
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(level);
    }
   public void LoadLevelMenu()
    {
        SceneManager.LoadScene("LevelsMenu");
    }
    public void FeedBack()
    {
        Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSfe-IbHGC93m3ysvZFCT8lD2ASLccXP6rexaZLjNLuM0D6Iyw/viewform");
    }
    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }
    public void MM()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
