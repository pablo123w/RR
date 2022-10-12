using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveScore : MonoBehaviour
{
    public float health;
    public float score;
    public LevelProgression lbl;
   
    public void Start()
    {
       
       
    }
    public void Update()
    {
       // score = lbl.ScorePercent;
    }
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData player = new PlayerData();
       // player.score = score;

        player.currentLevel = SceneManager.GetActiveScene();
        bf.Serialize(file, player);
        file.Close();
        Debug.Log("saved");
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData player = (PlayerData)bf.Deserialize(file);
            SceneManager.LoadScene(player.currentLevel.buildIndex);
            file.Close();
            //score = player.score;
            
        }
        else
        {
            Debug.Log("NOOOOOOOOOOOOO");
        }
    }
    public void saveButton()
    {
        Save();
    }
    public void loadButton()
    {
        Load();
    }

    [System.Serializable]
    class PlayerData
    {
        public float score;
        public Scene currentLevel;
    }
}

