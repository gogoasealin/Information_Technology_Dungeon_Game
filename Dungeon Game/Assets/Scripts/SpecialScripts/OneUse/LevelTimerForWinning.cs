using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelTimerForWinning : MonoBehaviour {

    public float levelTimer;
    public TMP_Text levelTimerText;
    private float timer;
    private GameObject gameController;
    private GameController gameControllerScript;
    private GameObject gameManager;
    private GameManager gameManagerScript;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameControllerScript = gameController.GetComponent<GameController>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        if (gameManager != null)
        {
            gameManagerScript = gameManager.GetComponent<GameManager>();
        }
        timer = levelTimer;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        levelTimerText.text = timer.ToString("F2");
        if (timer <= 0 && !gameControllerScript.death)
        {
            levelTimerText.text = "";
            GoToNextLevel();
        }
        if (gameControllerScript.death)
        {
            levelTimerText.text = "";
            Destroy(GetComponent<LevelTimerForWinning>());
        }
    }

    void GoToNextLevel()
    {
        int levelMax = 0;
        if (gameManagerScript != null)
        {
            gameManagerScript.Load(ref levelMax);
        }
        Scene scene = SceneManager.GetActiveScene();
        string nextLevel = scene.name;
        string nextLevelName = nextLevel.Substring(nextLevel.Length - 1);
        int lvlnumber = int.Parse(nextLevelName);
        lvlnumber++;
        int levelReached = lvlnumber;

        if (gameManagerScript != null)
        {
            if (levelReached > levelMax)
            {
                gameManagerScript.Save(levelReached);
            }
        }
        if (lvlnumber == 11)
        {
            SceneManager.LoadScene("End");
        }
        else SceneManager.LoadScene("level" + lvlnumber);
    }
}



