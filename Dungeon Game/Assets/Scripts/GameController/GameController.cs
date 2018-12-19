using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityStandardAssets.CrossPlatformInput;

public class GameController : MonoBehaviour
{
    public static GameController gameController;

    private GameObject player;
    private PlayerController playerControllerScript;
    public GameObject gameOverWindow;
    public GameObject pauseWindow;
    public GameObject backToMenuButton;
    public GameObject hintButton;
    //private GameObject gameManager;
   // private GameManager gameManagerScript;
    public int count;
    public int highScore;
    public int numberOfAllGames;
    public int levelReached;
    public int currentLevelReached;
    public bool death;
    //private PlayAdd playAdd;
    public bool pause;
    public bool resume;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //gameManager = GameObject.FindGameObjectWithTag("GameManager");
        //gameManagerScript = gameManager.GetComponent<GameManager>();
        playerControllerScript = player.GetComponent<PlayerController>();
        //gameManagerScript.Load();

        //playAdd = GetComponent<PlayAdd>();
        //playAdd.InitializeAdd();
        


        PrepareGame();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchPause();
        }
        if (pause)
        {
            Pause();
        }
        else if (!pause)
        {
            if (resume)
            {
                ResumeButton();
            }
        }
    }




    public void GameOver()
    {
        if (playerControllerScript != null) { 
            playerControllerScript.enabled = false;
        }
        death = true;
        //animatie de moarte

        Time.timeScale = 0;

        //numberOfAllGames += 1;
        //if (highScore < count)
        //{
        //    //new record
        //    highScore = count;
        //}
        EnableMenuText();
        // gameManagerScript.Save();
        if (gameOverWindow != null)
        {
            gameOverWindow.SetActive(true);
        }
        //if (numberOfAllGames >= 10)
        //{
        //    numberOfAllGames = 0;
        //    //playAdd.ShowAd();
        //}
        //else
        //{
        //    GameOverWindow.SetActive(true);
        //}

    }

    public void EnableMenuText()
    {
        if (backToMenuButton != null)
        {
            backToMenuButton.SetActive(true);
            hintButton.SetActive(true);
        }

    }

    public void DisableMenuText()
    {
        backToMenuButton.SetActive(false);
        hintButton.SetActive(false);
    }

    public void RestartButton()
    {
        gameOverWindow.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("" + scene.name); // current scene 

    }

    public void Pause()
    {
        Time.timeScale = 0;
        EnableMenuText();
        pauseWindow.SetActive(true);

    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        DisableMenuText();
        pauseWindow.SetActive(false);
        resume = false;
    }

    public void PrepareGame()
    {
        Time.timeScale = 1;
        pause = false;
        gameOverWindow.SetActive(false);
        pauseWindow.SetActive(false);
        backToMenuButton.SetActive(false);
        hintButton.SetActive(false);
    }

    public void SwitchPause()
    {
        if (pause)
        {
            pause = false;
            resume = true;
        }
        else if (!pause)
        {
            pause = true;
        }
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToHint()
    {
        Debug.Log("hint");
        //open YT;
    }
}
