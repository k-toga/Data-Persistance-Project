using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public InputField inputField;
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager gameManager = GameManager.Instance;
        highScoreText.text = "Best Score : " + gameManager.HighScoreName + " : " + gameManager.HighScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartClicked()
    {
        string playerName = inputField.text;
        if (playerName == "")
        {
            playerName = "No Name";
        }
        GameManager.Instance.PlayerName = playerName;
        SceneManager.LoadScene(1);
    }

    public void OnQuitCilcked()
    {
        GameManager.Instance.SaveHighScoreData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void OnClearHighScoreClicked()
    {
        GameManager gameManager = GameManager.Instance;

        gameManager.ClearHighScoreData();
        highScoreText.text = "Best Score : " + gameManager.HighScoreName + " : " + gameManager.HighScore;
    }
}
