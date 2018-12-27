using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public int levelReached;
    private GameObject[] levels;
    private GameManager gameManagerScript;




    private void Start()
    {
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameManagerScript.Load();
        levelReached = gameManagerScript.levelReached;
        levels = GameObject.FindGameObjectsWithTag("Level");
        string nextLevel;
        string nextLevelName;
        int lvlnumber;
        for (int i = 0  ; i < levels.Length; i++)
        {
            nextLevel = levels[i].name;
            if(levels[i].name.Length == 7)
            {
                nextLevelName = nextLevel.Substring(nextLevel.Length - 1);
                lvlnumber = int.Parse(nextLevelName);
                if (lvlnumber > levelReached)
                {
                    levels[i].SetActive(false);
                }
                if (lvlnumber == 1)
                {
                    levels[i].SetActive(true);
                }
            }
            else if(levels[i].name.Length == 8)
            {
                nextLevelName = nextLevel.Substring(nextLevel.Length - 2);
                lvlnumber = int.Parse(nextLevelName);
                if (lvlnumber > levelReached)
                {
                    levels[i].SetActive(false);
                }
                if (lvlnumber == 1)
                {
                    levels[i].SetActive(true);
                }
            }

        }
    }
}
