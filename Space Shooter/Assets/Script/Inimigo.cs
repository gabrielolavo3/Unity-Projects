using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public int quantVidaInimigo; // Variável para definir a quantidade de vida
    private float velocidadeY;
    public float velocidadeMinima,
                 velocidadeMaxima;
    public ParticleSystem particulaExplosaoPrefab; // Variável para atribuir o prefab da particula no Inspector
    
    void Start()
    {
        // Gerando um número aleatório entre o valor minimo e maximo definido
        velocidadeY = Random.Range(velocidadeMinima, velocidadeMaxima);
    }

    void Update()
    {
        // Acessa o velocity do Rigidbody2D e passa a posição horizontal(x) como 0, pois o inimigo se move somente na horizontal
        //  O valor é decrementado pois o inimigo deve se mover para baixo, caindo
        rigidbody.velocity = new Vector2(0, -velocidadeY);

        Camera camera = Camera.main;
        Vector3 posicaoNaCamera = camera.WorldToViewportPoint(transform.position);

        if (posicaoNaCamera.y < 0) 
        { 
            NaveJogador jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<NaveJogador>();
            jogador.Vida--; // Chama o metodo para decrementar a vida do jogador
            Destruir(false); // Chama o metodo para destruir o GameObject, mas o parâmetro é false pq o player não destruiu
        }
    }

    public void ReceberDano()
    {
        quantVidaInimigo--; // Decrementar 1 ponto de vida o inimigo
        if (quantVidaInimigo <= 0) 
        {
            Destruir(true);
        }
    }

    // Método para incrementar a pontuação e destruir o GameObject do inimigo
    private void Destruir(bool derrotado) 
    {
        // O valor bool serve para que a pontuação aumente somente quando o laser atingir o inimigo
        // NaveJogador é false, então a colisão da Nave e Inimigo não aumenta os pontos porque o If analisa se é true
        // Laser é true, então a colisão da Nave e Inimigo aumenta os pontos
        if (derrotado)
        {
            ControladorPontuacao.Pontuacao++;
        }

        // Criando Instância da Particula, passando o Prefab, a posição do inimigo, a rotação padrão e atribuindo a variável do tipo ParticleSystem
        ParticleSystem particula =  Instantiate(particulaExplosaoPrefab, transform.position,Quaternion.identity);
        Debug.Log("Particula Gerada");
        Destroy(particula.gameObject, 1f); // Destrói a particula após 1 segundo
        Destroy(this.gameObject);
    }
}
