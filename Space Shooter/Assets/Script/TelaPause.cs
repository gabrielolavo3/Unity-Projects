using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelaPause : MonoBehaviour
{
    public void AtivarPause()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }
    
    public void DesativarPause()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
