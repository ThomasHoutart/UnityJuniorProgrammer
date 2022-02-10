using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highscoreText;
    [SerializeField] TMP_InputField inputText;

    private HighScoreInfo highScore;
    void Start()
    {
        highScore = GameManager.Instance.highScore;
        highscoreText.text = $"Best Score: {highScore.player} : {highScore.score}";
    }

    public void StartNew()
    {
        GameManager.Instance.playerName = inputText.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // Original code to quit Unity player
#endif
    }
}
