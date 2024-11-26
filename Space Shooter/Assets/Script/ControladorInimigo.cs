using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorInimigo : MonoBehaviour
{
    private float tempoDecorrido;
    public Inimigo inimigoOriginal;

    void Start()
    {
        tempoDecorrido = 0;
    }
    
    void Update()
    {
        // Time.deltaTime retorna o tempo entre cada frame
        tempoDecorrido += Time.deltaTime;

        if (tempoDecorrido >= 1f) 
        {
            // Criando um novo inimigo e zerando o tempo acumulado
            tempoDecorrido = 0;

            // Usando a posi��o da Main Camera para gerar inimigos no topo da tela

            Vector2 posicaoMaxima = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            Vector2 posicaoMinima = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            float posicaoX = Random.Range(posicaoMinima.x, posicaoMaxima.x);

            Vector2 posicaoInimigo = new Vector2(posicaoX, posicaoMaxima.y);           

            Instantiate(inimigoOriginal, posicaoInimigo, Quaternion.identity);
        }
    }
}
