using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelTimerForWinning : MonoBehaviour {

    public float levelTimer;
    public TMP_Text levelTimerText;
    private float timer;
    private GameController gameController;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        timer = levelTimer;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        levelTimerText.text = timer.ToString("F2");
        if (timer <= 0 && !gameController.death)
        {
            levelTimerText.text = "";
            GoToNextLevel();
        }
        if (gameController.death)
        {
            levelTimerText.text = "";
            Destroy(GetComponent<LevelTimerForWinning>());
        }
    }

    void GoToNextLevel()
    {
        gameController.GetComponent<GoToNextLevel>().NexTLevel();
    }
}



