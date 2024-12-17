using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public int quantVidaInimigo; // Variável para definir a quantidade de vida no inspecto
    private float velocidadeY;
    public float velocidadeMinima,
                 velocidadeMaxima;
    public ParticleSystem particulaExplosaoPrefab; // Variável para atribuir o prefab da particula no Inspector
    public SpriteRenderer spriteRenderer; // Variável para atribuir o prefab de cada inimigo com o Script

    void Start()
    {
        Vector2 posicaoAtual = this.transform.position; // Obtém a posição no eixo X e Y do Player
        float metadeDaLargura = Largura / 2f; // Cálculo para mover o centro do Sprite, posteriormente, para esquerda ou direita
        float pontoReferenciaEsquerdo = posicaoAtual.x - metadeDaLargura; 
        float pontoReferenciaDireito = posicaoAtual.x + metadeDaLargura;

        Camera cam = Camera.main; // Pega a camêra do game
        Vector2 limiteInferiorEsquerdo = cam.ViewportToWorldPoint(Vector2.zero);
        Vector2 limiteSuperiorDireito = cam.ViewportToWorldPoint(Vector2.one);

        if (pontoReferenciaEsquerdo < limiteInferiorEsquerdo.x) // Saindo pela esquerda
        {
            float posicaoX = limiteInferiorEsquerdo.x + metadeDaLargura; //Soma para fazer o Inimigo voltar ao limite da visão caso saia pela esquerda
            this.transform.position = new Vector2(posicaoX, posicaoAtual.y); // Atualiza a posição do jogador, passando a posicaoX e mantendo a posição Y
        }
        else if (pontoReferenciaDireito > limiteSuperiorDireito.x) 
        { 
            float posicaoX = limiteSuperiorDireito.x - metadeDaLargura; //Subtração para fazer o Inimigo voltar ao limite da visão caso saia pela esquerda
            this.transform.position = new Vector2(posicaoX, posicaoAtual.y);
        }

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

    // Método para retirar a vida do inimigo através da colisão de outros GameObjects
    public void ReceberDano()
    {
        quantVidaInimigo--; // Decrementar 1 ponto de vida o inimigo
        if (quantVidaInimigo <= 0) 
        {
            Destruir(true);
        }
    }

    // Propriedade Getter
    private float Largura
    {
        get 
        { 
            Bounds bounds = spriteRenderer.bounds; // O Bounds retorna as dimensões de um sprite 
            Vector3 tamanho = bounds.size; // Obtém as dimensões X (Altura), Y (Largura) e Z (Profundidade)
            return tamanho.y;
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
        Destroy(this.gameObject); // Destrói o GameObject do Inimigo
    }
}
