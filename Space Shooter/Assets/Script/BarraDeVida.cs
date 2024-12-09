using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraDeVida : MonoBehaviour
{
    public GameObject[] pontosVermelhos; // Array para adicionar o Sprite do GameObject
    
    public void ExibirVidas(int quantVida) 
    {
        // Laço para percorrer o Array de GameObject
        for (int a = 0; a < pontosVermelhos.Length; a++) 
        {
            if (a < quantVida) 
            { 
                // Caso verdade, ativa a barra de vida
                pontosVermelhos[a].gameObject.SetActive(true);
            }
            else 
            {
                // Caso mentira, desativa gradualmemte os pontos da barra de vida
                pontosVermelhos[a].gameObject.SetActive(false);
            }
        } 
    }
}
