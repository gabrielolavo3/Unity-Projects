using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveJogador : MonoBehaviour
{
    private const int QuantidadeMaximaVida = 5;
    public new Rigidbody2D rigidbody; // Atributo do tipo Rigidbody2D para Fisica2D    
    public float velocidadeMovimento; // Variável para inserir o valor no Inspector    
    private int vidas;
    private GamerOver telaGamerOver;
    public SpriteRenderer spriteRenderer; // Variável para obter o Sprite do Jogador

    // Start é chamado uma única vez antes do primeiro frame
    void Start()
    {
        Debug.Log("Imprimindo no console da Unity e usando o método Start");
        
        ControladorPontuacao.Pontuacao = 0; // Define a pontuação para 0 ao iniciar o jogo
        vidas = QuantidadeMaximaVida;        
        GameObject gamerOverObject = GameObject.FindGameObjectWithTag("Gamer Over"); // Variável GameObject para buscar o 1º GameObject com a Tag "Gamer Over"        
        telaGamerOver = gamerOverObject.GetComponent<GamerOver>(); // Variável do tipo GamerOver recebendo o GameObject com a Tag e buscando o componente
        telaGamerOver.EsconderTela(); // Chama metodo para desativar a tela de GamerOver no inicio do Play
    }

    // Update é chamado a cada frame
    void Update()
    {
        /*
        // Trecho que controla a movimentação do Player
        float horizontal = Input.GetAxis("Horizontal"), // Recebe o clique das teclas A e D, do eixo horizontal
              vertical = Input.GetAxis("Vertical"), // Recebe o clique das teclas W e S, do eixo vertical
              velocidadeX = horizontal * this.velocidadeMovimento,
              velocidadeY = vertical * this.velocidadeMovimento;

        this.rigidbody.velocity = new Vector2(velocidadeX, velocidadeY); // Acessa a propriedade velocity de Rigidbody2D e passar um new Vector2 que recebe a posicao X e Y
        */
        VerificarLimiteDaTela();
    }

    private void VerificarLimiteDaTela() 
    { 
        Vector2 posicaoAtualJogador = this.transform.position; // Recebe a posição em tempo real do jogador na cena
        float metadeDaLargura = Largura / 2f, // Variáveis para fazer o posicionamento da nave para impedir que a nave saia do limite da camêra
              metadeDaAltura = Altura / 2f;

        Camera camera = Camera.main; // Variável para a camêra principal
        Vector2 limiteInferiorEsquerdo = camera.ViewportToWorldPoint(Vector2.zero); // Recebe a posição do viewPort e converte para coordenadas 2d, junto com um array com posição (0,0)
        Vector2 limiteSuperiorDireito = camera.ViewportToWorldPoint(Vector2.one); // Recebe a posição do viewPort e converte para coordenadas 2d, junto com um array com posição (1,1)

        float pontoDeReferenciaLadoEsquerdo = posicaoAtualJogador.x - metadeDaLargura,
              pontoDeReferenciaLadoDireito = posicaoAtualJogador.x + metadeDaLargura;

        // Verifica se o jogador saiu pela esquerda, analisando se a posição Horizontal é menor do que a posição Horizontal do Limite
        if (pontoDeReferenciaLadoEsquerdo < limiteInferiorEsquerdo.x) 
        {
            // Atualiza a posição horizontal do Player para a posição do Limite Esquerdo e manter a posição Vertical atual do Player
            // A soma faz com que, quando o pixel da nva sai do limite, seja somado metadeDaLargura da nave para voltar a mesma posição
            transform.position = new Vector2(limiteInferiorEsquerdo.x + metadeDaLargura, posicaoAtualJogador.y); 
        }
        else if (pontoDeReferenciaLadoDireito > limiteSuperiorDireito.x) // Verifica a saida pelo lado direito da camêra
        {
            transform.position = new Vector2(limiteSuperiorDireito.x - metadeDaLargura, posicaoAtualJogador.y);
        }
        
        posicaoAtualJogador = this.transform.position; // Atualiza a posição do jogador para verificar o superior e inferior porquê houve mudança na posição da esquerda e na direita
        // Esss trecho permite que o Player não saia pela diagonal

        float pontDeReferencialLadoSuperior = posicaoAtualJogador.y + metadeDaAltura,
              pontoDeReferenciaLadoInferior = posicaoAtualJogador.y - metadeDaAltura;

        if (pontDeReferencialLadoSuperior > limiteSuperiorDireito.y) // Verifica a saida pelo lado de cima da camêra
        {
            transform.position = new Vector2(posicaoAtualJogador.x, limiteSuperiorDireito.y - metadeDaAltura);
        }
        else if (pontoDeReferenciaLadoInferior < limiteInferiorEsquerdo.y) // Verifica a saida inferior da camêra
        {
            transform.position = new Vector2(posicaoAtualJogador.x, limiteInferiorEsquerdo.y + metadeDaAltura);
        }
    }

    public float Largura
    {
        get 
        { 
            Bounds bound = spriteRenderer.bounds; // Obtém os limites de um spriteRenderer. Esse limite é uma caixa em torno do sprite
            Vector3 tamanhoHorizontalJogador = bound.size; // Retorna o tamanho de um sprite: Largura(Horizontal/X), Altura(Vertical/Y) e Rotação(Z)
            return tamanhoHorizontalJogador.x; // Retorna somente a largura
        }
    }

    public float Altura
    {
        get
        {
            Bounds bound = spriteRenderer.bounds; 
            Vector3 tamanhoHorizontalJogador = bound.size; 
            return tamanhoHorizontalJogador.y; // Retorna somente a altura
        }
    }

    // Propriedade de acesso get e set da vida do Player
    public int Vida
    {
        get
        {
            return vidas;
        }

        set 
        {
            this.vidas = value;

            if (vidas >= QuantidadeMaximaVida) // Verificação para impedir que o Jogador tenha mais do que o permitido
            { 
                vidas = QuantidadeMaximaVida;
            }
            else if (vidas <= 0) 
            { 
                vidas = 0;
                gameObject.SetActive(false); // Desativa o Inspector do Jogador
                telaGamerOver.Exibir(); // Chama o método para mostrará a Tela de Gamer Over, pois a vida do Player zerou
            }
        }
    }

    // Método para a colisão entre o Jogador e o Inimigo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Compara se o Jogador colidiu com um GameObject com a Tag "Inimigo"
        if (collision.CompareTag("Inimigo")) 
        {
            Vida--; // Decrementa a vida pois há um Set na Propriedade de Acesso
            Debug.Log("Vida atual " + Vida);
            Inimigo inimigo = collision.GetComponent<Inimigo>();
            inimigo.ReceberDano(); // Chama o método do script inimigo para retirar ponto de vida o Inimigo com a colisão entre o Player
        }
        else if (collision.CompareTag("ItemVida")) // Verifica colisão do Player com o item
        { 
            ItemVida itemVida = collision.GetComponent<ItemVida>(); // Acessa diretamente o Script ItemVida com todas as configurações e dados
            Vida += itemVida.QuantidadeVida; // Incrementa a propriedade da vida do Player com a QuantidadeVida que o item recupera do usuário
            itemVida.ColetarItem(); // Chama o método para destruir o item após a colisão com o Player
        }
    }    
}