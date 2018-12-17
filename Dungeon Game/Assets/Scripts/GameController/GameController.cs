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
    public GameObject GameOverWindow;
    public GameObject PauseWindow;
    public GameObject backToMenuButton;
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
        if (GameOverWindow != null)
        {
            GameOverWindow.SetActive(true);
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
        // poate timer pe stelute? 
        if (backToMenuButton != null)
        {
            backToMenuButton.SetActive(true);
        }

    }

    public void DisableMenuText()
    {
        backToMenuButton.SetActive(false);
    }

    public void RestartButton()
    {
        GameOverWindow.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("" + scene.name); // current scene 

    }

    public void Pause()
    {
        Time.timeScale = 0;
        EnableMenuText();
        PauseWindow.SetActive(true);

    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        DisableMenuText();
        PauseWindow.SetActive(false);
        playerControllerScript.resume = false;
    }

    public void PrepareGame()
    {
        Time.timeScale = 1;
        pause = false;
        GameOverWindow.SetActive(false);
        PauseWindow.SetActive(false);
        backToMenuButton.SetActive(false);
    }

    public void SwitchPause()
    {
        if (playerControllerScript != null && playerControllerScript.enabled)
        {
            if (playerControllerScript.pause)
            {
                playerControllerScript.pause = false;
                playerControllerScript.resume = true;
            }
            else if (!playerControllerScript.pause)
            {
                playerControllerScript.pause = true;
            }
        }
    }


}
