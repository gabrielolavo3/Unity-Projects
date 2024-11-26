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
        // Gerando um n�mero aleat�rio entre o valor minimo e maximo definido
        velocidadeY = Random.Range(velocidadeMinima, velocidadeMaxima);
    }

    void Update()
    {
        rigidbody.velocity = new Vector2(0, -velocidadeY);
    }

    // M�todo para incrementar a pontua��o e destruir o GameObject do inimigo
    public void Destuir(bool derrotado) 
    {
        // O valor bool serve para que a pontua��o aumente somente quando o laser atingir o inimigo
        // NaveJogador � false, ent�o a colis�o da Nave e Inimigo n�o aumenta os pontos porque o If analisa se � true
        // Laser � true, ent�o a colis�o da Nave e Inimigo aumenta os pontos
        if (derrotado)
        {
            ControladorPontuacao.Pontuacao++;
        }
        Destroy(this.gameObject);
    }
}
