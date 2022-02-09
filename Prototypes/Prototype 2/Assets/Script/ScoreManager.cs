using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;
    
    public static ScoreManager instance;
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void incrementScore()
    {
        score += 1;
        Debug.Log($"Scores = {score}");
    }

    public void loseLife()
    {
        lives -= 1;
        if (lives > 0)
            Debug.Log($"Lives = {lives}");
        else if (lives == 0)
            Debug.Log("Game Over");
    }
}
