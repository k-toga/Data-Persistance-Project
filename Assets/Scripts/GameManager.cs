using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int HighScore = 0;
    public string HighScoreName = "Name";
    public string PlayerName = "";

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadHighScoreData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [Serializable]
    class HighScoreData
    {
        public int score;
        public string name;
    }

    public void SaveHighScoreData()
    {
        HighScoreData data = new HighScoreData();
        data.score = HighScore;
        data.name = HighScoreName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }

    public void LoadHighScoreData()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScoreData data = new HighScoreData();

            data = JsonUtility.FromJson<HighScoreData>(json);
            HighScore = data.score;
            HighScoreName = data.name;
        }
    }

    public void ClearHighScoreData()
    {
        HighScore = 0;
        HighScoreName = "Name";
    }
}
