using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;
    public GameController gameController;
    public int levelReached;

    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerinfo.dat");

        PlayerInfo data = new PlayerInfo();

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        data.levelsReached = levelReached;
        data.nextAddFromDeath = gameController.nextAddFromDeath;
        data.nextAddFromLvls = gameController.nextAddFromLvls;

        bf.Serialize(file, data);
        file.Close();
    }


    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerinfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.dat", FileMode.Open);
            if (file.Length > 0)
            {
                PlayerInfo data = (PlayerInfo)bf.Deserialize(file);
                levelReached = data.levelsReached;
                if (GameObject.FindGameObjectWithTag("GameController") != null) {
                    gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
                    
                    gameController.nextAddFromDeath = data.nextAddFromDeath;
                    gameController.nextAddFromLvls = data.nextAddFromLvls;
                }
            }
            file.Close();
        }       
    }

}

[System.Serializable]
class PlayerInfo
{
    public int levelsReached;
    public int nextAddFromDeath;
    public int nextAddFromLvls;
}



