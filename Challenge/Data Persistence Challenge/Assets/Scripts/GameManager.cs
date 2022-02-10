using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[System.Serializable]
public struct HighScoreInfo
{
    public string player;
    public int score;

    public HighScoreInfo(string player, int score)
    {
        this.player = player;
        this.score = score;
    }
}
public class GameManager : MonoBehaviour
{
    private readonly HighScoreInfo defaultScore = new HighScoreInfo("Bob", 0);

    public static GameManager Instance; // Singleton

    public string playerName;

    public HighScoreInfo highScore;

    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
        // ResetScore();
        InitializeScore();
    }
    
    [System.Serializable]
    class SaveData
    {
        public HighScoreInfo highScore;
    }
    
    // Method to reset score
    private void ResetScore()
    {
        highScore = defaultScore;
        SaveHighscore();
    }
    

    private void InitializeScore()
    {
        LoadHighscore();
    }

    public void NewHighScore(int score)
    {
        highScore = new HighScoreInfo(playerName, score);
        SaveHighscore();
    }
    
    public void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
            
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Debug.Log(data.highScore.player);
            Debug.Log(data.highScore.score);
            highScore = data.highScore;
        }
    }
}
