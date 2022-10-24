using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SaveScore : MonoBehaviour
{
    public float highscore;
    private LevelProgression lvl;
    public Text score;
     
    public void Start()
    {
        lvl = GetComponent<LevelProgression>();
        highscore = lvl.Score;
        //PrintHigh();  
    }
    
    
    public void SaveHigh()
    {
        highscore = lvl.Score;
        PlayerPrefs.SetFloat("High Score", highscore);

        Debug.Log("High Score is " + highscore);
    }
}

































//    public float health;
//    public float score;
//    public LevelProgression lbl;
   
//    public void Start()
//    {
       
       
//    }
//    public void Update()
//    {
//       // score = lbl.ScorePercent;
//    }
//    public void Save()
//    {
//        BinaryFormatter bf = new BinaryFormatter();
//        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

//        PlayerData player = new PlayerData();
//       // player.score = score;

//        player.currentLevel = SceneManager.GetActiveScene();
//        bf.Serialize(file, player);
//        file.Close();
//        Debug.Log("saved");
//    }

//    public void Load()
//    {
//        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
//        {
//            BinaryFormatter bf = new BinaryFormatter();
//            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
//            PlayerData player = (PlayerData)bf.Deserialize(file);
//            SceneManager.LoadScene(player.currentLevel.buildIndex);
//            file.Close();
//            //score = player.score;
            
//        }
//        else
//        {
//            Debug.Log("NOOOOOOOOOOOOO");
//        }
//    }
//    public void saveButton()
//    {
//        Save();
//    }
//    public void loadButton()
//    {
//        Load();
//    }

//    [System.Serializable]
//    class PlayerData
//    {
//        public float score;
//        public Scene currentLevel;
//    }
//}

