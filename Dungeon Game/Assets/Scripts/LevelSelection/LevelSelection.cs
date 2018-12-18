using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour {

    public int levelID;

    public void StartLevel()
    {
        SceneManager.LoadScene("Level" + levelID);
    }
}
