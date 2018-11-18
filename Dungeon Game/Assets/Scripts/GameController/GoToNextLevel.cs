using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour {

    private GameObject gameManager;
    private GameManager gameManagerScript;
    private GameObject gameController;
    private GameController gameControllerScript;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        if (gameManager != null)
        {
            gameManagerScript = gameManager.GetComponent<GameManager>();
        }
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameControllerScript = gameController.GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !gameControllerScript.death)
        {
            NexTLevel();
        }
    }

    public void NexTLevel()
    {
        int levelMax = 0;
        if (gameManagerScript != null)
        {
            gameManagerScript.Load(ref levelMax);
        }
        Scene scene = SceneManager.GetActiveScene();
        string nextLevel = scene.name;
        string nextLevelName;
        if (scene.name.Length == 6)
        {
            nextLevelName = nextLevel.Substring(nextLevel.Length - 1);
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
           
            if (lvlnumber == 19)
            {
                SceneManager.LoadScene("End");
            }
            else SceneManager.LoadScene("level" + lvlnumber);
        }
        else if(scene.name.Length == 7)
        {
            nextLevelName = nextLevel.Substring(nextLevel.Length - 2);
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
            if (lvlnumber == 19)
            {
                SceneManager.LoadScene("End");
            }
            else SceneManager.LoadScene("level" + lvlnumber);
        }


    }
}
