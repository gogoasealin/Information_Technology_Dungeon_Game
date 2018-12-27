using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour {

    private GameObject gameManager;
    private GameManager gameManagerScript;
    private GameController gameController;

    public int levelMax;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        if (gameManager != null)
        {
            gameManagerScript = gameManager.GetComponent<GameManager>();
        }
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !gameController.death)
        {
            NexTLevel();
        }
    }

    public void NexTLevel()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>() != null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().dontdieOutOfScreen = true;
        }

        if (gameManagerScript != null)
        {
            levelMax = gameManagerScript.levelReached;
            Scene scene = SceneManager.GetActiveScene();
            string nextLevel = scene.name;
            string nextLevelName;
            if (scene.name.Length == 6)
            {
                nextLevelName = nextLevel.Substring(nextLevel.Length - 1);
                int lvlnumber = int.Parse(nextLevelName);
                lvlnumber++;
                int levelReached = lvlnumber;
                if (levelReached > levelMax)
                {
                    gameManagerScript.levelReached = levelReached;
                }
                SceneManager.LoadScene("level" + lvlnumber);
            }
            else if (scene.name.Length == 7)
            {
                nextLevelName = nextLevel.Substring(nextLevel.Length - 2);
                int lvlnumber = int.Parse(nextLevelName);
                lvlnumber++;
                int levelReached = lvlnumber;
                if (levelReached > levelMax)
                {
                    gameManagerScript.levelReached = levelReached;
                }
                SceneManager.LoadScene("level" + lvlnumber);
            }
            gameController.nextAddFromLvls +=1;
            gameManagerScript.Save();
        }
    }
}
