using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;

    void Start()
    {
        Time.timeScale = 1;
    }

    public void GameOverAtivar()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void Loading()
    {
        SceneManager.LoadScene(0);
    }
}
