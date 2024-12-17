using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public int quantVidaInimigo; // Vari�vel para definir a quantidade de vida no inspecto
    private float velocidadeY;
    public float velocidadeMinima,
                 velocidadeMaxima;
    public ParticleSystem particulaExplosaoPrefab; // Vari�vel para atribuir o prefab da particula no Inspector
    public SpriteRenderer spriteRenderer; // Vari�vel para atribuir o prefab de cada inimigo com o Script

    void Start()
    {
        Vector2 posicaoAtual = this.transform.position; // Obt�m a posi��o no eixo X e Y do Player
        float metadeDaLargura = Largura / 2f; // C�lculo para mover o centro do Sprite, posteriormente, para esquerda ou direita
        float pontoReferenciaEsquerdo = posicaoAtual.x - metadeDaLargura; 
        float pontoReferenciaDireito = posicaoAtual.x + metadeDaLargura;

        Camera cam = Camera.main; // Pega a cam�ra do game
        Vector2 limiteInferiorEsquerdo = cam.ViewportToWorldPoint(Vector2.zero);
        Vector2 limiteSuperiorDireito = cam.ViewportToWorldPoint(Vector2.one);

        if (pontoReferenciaEsquerdo < limiteInferiorEsquerdo.x) // Saindo pela esquerda
        {
            float posicaoX = limiteInferiorEsquerdo.x + metadeDaLargura; //Soma para fazer o Inimigo voltar ao limite da vis�o caso saia pela esquerda
            this.transform.position = new Vector2(posicaoX, posicaoAtual.y); // Atualiza a posi��o do jogador, passando a posicaoX e mantendo a posi��o Y
        }
        else if (pontoReferenciaDireito > limiteSuperiorDireito.x) 
        { 
            float posicaoX = limiteSuperiorDireito.x - metadeDaLargura; //Subtra��o para fazer o Inimigo voltar ao limite da vis�o caso saia pela esquerda
            this.transform.position = new Vector2(posicaoX, posicaoAtual.y);
        }

        // Gerando um n�mero aleat�rio entre o valor minimo e maximo definido
        velocidadeY = Random.Range(velocidadeMinima, velocidadeMaxima);
    }

    void Update()
    {
        // Acessa o velocity do Rigidbody2D e passa a posi��o horizontal(x) como 0, pois o inimigo se move somente na horizontal
        //  O valor � decrementado pois o inimigo deve se mover para baixo, caindo
        rigidbody.velocity = new Vector2(0, -velocidadeY);

        Camera camera = Camera.main;
        Vector3 posicaoNaCamera = camera.WorldToViewportPoint(transform.position);

        if (posicaoNaCamera.y < 0) 
        { 
            NaveJogador jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<NaveJogador>();
            jogador.Vida--; // Chama o metodo para decrementar a vida do jogador
            Destruir(false); // Chama o metodo para destruir o GameObject, mas o par�metro � false pq o player n�o destruiu
        }
    }

    // M�todo para retirar a vida do inimigo atrav�s da colis�o de outros GameObjects
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
            Bounds bounds = spriteRenderer.bounds; // O Bounds retorna as dimens�es de um sprite 
            Vector3 tamanho = bounds.size; // Obt�m as dimens�es X (Altura), Y (Largura) e Z (Profundidade)
            return tamanho.y;
        }
    }

    // M�todo para incrementar a pontua��o e destruir o GameObject do inimigo
    private void Destruir(bool derrotado) 
    {
        // O valor bool serve para que a pontua��o aumente somente quando o laser atingir o inimigo
        // NaveJogador � false, ent�o a colis�o da Nave e Inimigo n�o aumenta os pontos porque o If analisa se � true
        // Laser � true, ent�o a colis�o da Nave e Inimigo aumenta os pontos
        if (derrotado)
        {
            ControladorPontuacao.Pontuacao++;
        }

        // Criando Inst�ncia da Particula, passando o Prefab, a posi��o do inimigo, a rota��o padr�o e atribuindo a vari�vel do tipo ParticleSystem
        ParticleSystem particula =  Instantiate(particulaExplosaoPrefab, transform.position,Quaternion.identity);
        Debug.Log("Particula Gerada");
        Destroy(particula.gameObject, 1f); // Destr�i a particula ap�s 1 segundo
        Destroy(this.gameObject); // Destr�i o GameObject do Inimigo
    }
}
