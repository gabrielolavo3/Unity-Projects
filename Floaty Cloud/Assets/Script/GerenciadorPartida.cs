using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorPartida : MonoBehaviour
{
    private bool partidaIniciada;

    private void Awake()
    {
        Time.timeScale = 0;
        Application.targetFrameRate = 60;
    }
    
    void Update()
    {
        if (partidaIniciada) 
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        { 
            partidaIniciada = true;
            Time.timeScale = 1;
        }
    }

    public void ReiniciarPartida() 
    {
        SceneManager.LoadScene(0);
    }
}