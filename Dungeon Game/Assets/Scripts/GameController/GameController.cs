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

    private GameManager gameManagerScript;

    public int levelReached;
    public int currentLevelReached;
    public int nextAddFromDeath;
    public int nextAddFromLvls;
    public bool death;
    private AdsManager adsManager;
    public bool pause;
    public bool resume;
    [SerializeField] AudioSource audioSourceDeath;

   

    private string[] levelsHint = new string[] {
        "https://www.youtube.com/watch?v=-qEtZr9619U",
        "https://www.youtube.com/watch?v=F_S8UleLwUM&ab_channel=CodrinBradea%3ASatana",
        "https://www.youtube.com/watch?v=1-z7sIcIE1M" };

    private void Awake()
    {
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameManagerScript.Load();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControllerScript = player.GetComponent<PlayerController>();
        

        adsManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AdsManager>();
        adsManager.InitializeAdd();
        
        audioSourceDeath = GetComponent<AudioSource>();
        PrepareGame();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
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
        if(death)
        {
            player.transform.localScale -= new Vector3(0.003f, 0.003f, 0);
            if (player.transform.localScale.x <= 0.001f)
            {
                death = false;
                AfterGameOver();
            }
        }
    }


    public void AfterGameOver()
    {
        Time.timeScale = 0;

        nextAddFromDeath += 1;

        if(nextAddFromDeath >= 6 || nextAddFromLvls >=3)
        {
            adsManager.ShowAd();      
        }
        else
        {
            ShowDeathMenus();
            gameManagerScript.Save();
        }

    }

    public void AddShowSuccesfully()
    {
        ShowDeathMenus();
        nextAddFromDeath = 0;
        nextAddFromLvls = 0;
        gameManagerScript.Save();
    }

    public void AddFailed()
    {
        ShowDeathMenus();
    }

    public void ShowDeathMenus()
    {
        EnableMenuText();
        gameOverWindow.SetActive(true);
    }

    public void GameOver()
    {
        transform.position = player.transform.position;
        if (playerControllerScript != null) { 
            playerControllerScript.enabled = false;
        }
        death = true;
        player.GetComponent<AudioSource>().Stop();
        audioSourceDeath.Play();     

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
        SceneManager.LoadScene("LevelSelection");
    }

    public void GoToHint()
    {
        Scene scene = SceneManager.GetActiveScene();
        string nextLevel = scene.name;
        int index = 15; // fara 16
        if (scene.name.Length == 6)
        {
            index = int.Parse(nextLevel.Substring(nextLevel.Length - 1));
        }
        else if(scene.name.Length == 7)
        {
            index = int.Parse(nextLevel.Substring(nextLevel.Length - 2));
        }

        if (index <= levelsHint.Length)
        {
            Application.OpenURL(levelsHint[index-1]); 
        }
    }
}
