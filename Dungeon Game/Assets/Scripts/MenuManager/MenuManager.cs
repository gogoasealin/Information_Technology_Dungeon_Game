using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public void GoToLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoBackToMenu();
        }
    }

}
