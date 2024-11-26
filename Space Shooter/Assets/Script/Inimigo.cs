using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    private float velocidadeY;
    public float velocidadeMinima,
                 velocidadeMaxima;
    
    void Start()
    {
        // Gerando um número aleatório entre o valor minimo e maximo definido
        velocidadeY = Random.Range(velocidadeMinima, velocidadeMaxima);
    }

    void Update()
    {
        rigidbody.velocity = new Vector2(0, -velocidadeY);
    }

    // Método para incrementar a pontuação e destruir o GameObject do inimigo
    public void Destuir(bool derrotado) 
    {
        // O valor bool serve para que a pontuação aumente somente quando o laser atingir o inimigo
        // NaveJogador é false, então a colisão da Nave e Inimigo não aumenta os pontos porque o If analisa se é true
        // Laser é true, então a colisão da Nave e Inimigo aumenta os pontos
        if (derrotado)
        {
            ControladorPontuacao.Pontuacao++;
        }
        Destroy(this.gameObject);
    }
}
