using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class GameManager : MonoBehaviour
{

    public string playerName;
    public static GameManager Instance;
    public string highScoreOwner;
    public int allTimeHighScore;

    void Awake()
    {
        if(Instance != null)
        { 
            Destroy(gameObject); 
            return;
        }
        Instance = this;
        Load_High_Scores();
        DontDestroyOnLoad(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    public void Quit_Game()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else 
            Application.Quit();
        #endif
    }

    public void Start_Game()
    {
        SceneManager.LoadScene("main");
    }

    public void Reset_High_Scores()
    {
        Save_High_Score(0);
        Load_High_Scores();
    }
    
    public void Load_High_Scores()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData inputData = JsonUtility.FromJson<SaveData>(json);
            highScoreOwner = inputData.playerName;
            allTimeHighScore = inputData.highScore;
        }
        else
        {
            highScoreOwner = "No one yet";
            allTimeHighScore = 0;
        }
    }

    public void Save_High_Score(int newHighScore, string newHighScoreOwner = "No one yet")
    {
        allTimeHighScore = newHighScore;
        highScoreOwner = newHighScoreOwner;
        SaveData data = new SaveData();
        data.playerName = newHighScoreOwner;
        data.highScore = newHighScore; //Work in progress
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
        Debug.Log("highscore written");
    }

    [System.Serializable]
    public class SaveData 
    {
        public string playerName;
        public int highScore;
    }

}
