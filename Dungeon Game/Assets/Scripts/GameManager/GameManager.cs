using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;
    public GameObject levelManager;
    public LevelManager levelManagerScript;

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


    public void Save(int levelReached)
    {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerinfo.dat");

        PlayerInfo data = new PlayerInfo();

        data.levelsReached = levelReached;      

        bf.Serialize(file, data);
        file.Close();


    }


    public void Load(ref int levelReached)
    {

        if (File.Exists(Application.persistentDataPath + "/playerinfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.dat", FileMode.Open);
            PlayerInfo data = (PlayerInfo)bf.Deserialize(file);
            file.Close();
            levelReached = data.levelsReached;
        }
    }
}

[System.Serializable]
class PlayerInfo
{
    public int levelsReached;
}



