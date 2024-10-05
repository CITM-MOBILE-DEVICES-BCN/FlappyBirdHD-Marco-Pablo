using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public static Score Instance;

    [SerializeField] private TextMeshProUGUI CurrentScoreText;
    [SerializeField] private TextMeshProUGUI HighScoreText;

    private int score;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        CurrentScoreText.text = score.ToString();
        HighScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        if(score> PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score); 
            HighScoreText.text =score.ToString();
        }
    }
    public void UpdateScore()
    {
        score++;
        CurrentScoreText.text = score.ToString();
        UpdateHighScore();
    }
}
