using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject canvas;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Time.timeScale = 0.9f;
    }

    public void GameOver()
    {
        canvas.SetActive(true);
        canvas.GetComponent<Animator>().Play("GameOverEnter");
        if (canvas.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("GameOverEnter"))
        {
            Time.timeScale = 0;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   


}
