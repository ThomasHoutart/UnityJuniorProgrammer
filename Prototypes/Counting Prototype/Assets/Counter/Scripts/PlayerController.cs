using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    [SerializeField] Text ballRemainingText;
    [SerializeField] GameObject GameOverText;
    [SerializeField] GameObject RestartButton;

    [SerializeField] int ballAmount = 30;
    
    private int ballRemaining;
    
    void Start()
    {
        ObjectPool.SharedInstance.amountToPool = ballAmount;
        ballRemaining = ballAmount;
        UpdateBallRemainingText();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ballRemaining != 0)
        {
            SpawnBall();
            UpdateBallRemainingText();
        }
        else if (ballRemaining == 0)
        {
            GameOver();
        }
    }

    void SpawnBall()
    {
        ballRemaining--;
        GameObject ball = ObjectPool.SharedInstance.GetPooledObject();
        if (ball != null)
        {
            ball.transform.position = transform.position;
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.SetActive(true);
        }
    }

    void UpdateBallRemainingText()
    {
        ballRemainingText.text = $"Ball: {ballRemaining}";
    }

    void GameOver()
    {
        gameObject.SetActive(false);
        GameOverText.SetActive(true);    
        RestartButton.SetActive(true);    
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
