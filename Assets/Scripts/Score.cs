using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public static Score Instance;

    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

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
        currentScoreText.text = score.ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        if(score> PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score); 
            highScoreText.text =score.ToString();
        }
    }
    public void UpdateScore()
    {
        score++;
        AudioManager.instance.PlaySFX("Score");
        currentScoreText.text = score.ToString();
        UpdateHighScore();
        Debug.Log("Score: " + score);
        Debug.Log("High Score: " + PlayerPrefs.GetInt("HighScore"));
    }
}
