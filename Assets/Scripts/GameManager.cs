using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject Canvas;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Time.timeScale = 0.9f;
    }

    public void GameOver()
    {
        Canvas.SetActive(true);
        Canvas.GetComponent<Animator>().Play("GameOverEnter");
        if (Canvas.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("GameOverEnter"))
        {
            Time.timeScale = 0;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   


}
