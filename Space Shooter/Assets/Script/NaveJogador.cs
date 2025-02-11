using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveJogador : MonoBehaviour
{
    private const int QuantidadeMaximaVida = 5;
    public new Rigidbody2D rigidbody; // Atributo do tipo Rigidbody2D para Fisica2D    
    public float velocidadeMovimento; // Vari�vel para inserir o valor no Inspector    
    private int vidas;
    private GamerOver telaGamerOver;
    public SpriteRenderer spriteRenderer; // Vari�vel para obter o Sprite do Jogador
    public EfeitoPowerUp powerUpAtual;
    [SerializeField] private ControladorArma controladorArma;
    [SerializeField] private Escudo escudo;
    private ControladorAudio controladorAudio;

    // Start � chamado uma �nica vez antes do primeiro frame
    void Start()
    {
        Debug.Log("Imprimindo no console da Unity e usando o m�todo Start");
        
        ControladorPontuacao.Pontuacao = 0; // Define a pontua��o para 0 ao iniciar o jogo
        vidas = QuantidadeMaximaVida;        
        GameObject gamerOverObject = GameObject.FindGameObjectWithTag("Gamer Over"); // Vari�vel GameObject para buscar o 1� GameObject com a Tag "Gamer Over"        
        telaGamerOver = gamerOverObject.GetComponent<GamerOver>(); // Vari�vel do tipo GamerOver recebendo o GameObject com a Tag e buscando o componente
        telaGamerOver.EsconderTela(); // Chama metodo para desativar a tela de GamerOver no inicio do Play
        
        EquiparArmaDisparoAlternado(); // Defini a arma de �nicio
        escudo.DesativarEscudo();
        controladorAudio = GameObject.FindObjectOfType<ControladorAudio>(); // Busca na cena um objeto com o script ControladorAudio e traz a refer�ncia dele para NaveJogador
    }

    // Update � chamado a cada frame
    void Update()
    {
        // Trecho que controla a movimenta��o do Player
        float horizontal = Input.GetAxis("Horizontal"); // Recebe o clique das teclas A e D, do eixo horizontal
        float vertical = Input.GetAxis("Vertical"); // Recebe o clique das teclas W e S, do eixo vertical
        float velocidadeX = horizontal * this.velocidadeMovimento;
        float velocidadeY = vertical * this.velocidadeMovimento;

        this.rigidbody.velocity = new Vector2(velocidadeX, velocidadeY); // Acessa a propriedade velocity de Rigidbody2D e passar um new Vector2 que recebe a posicao X e Y        

        VerificarLimiteDaTela();

        if (powerUpAtual != null) 
        { 
            powerUpAtual.AtualizarTempo();
            
            if (!powerUpAtual.VerificarAtivo) 
            {
                powerUpAtual.RemoverEfeito(this);
                powerUpAtual = null;
            }
        }        
    }

    // M�todos para mudar a arma e permite acesso do PowerUp �s armas, mesmo sem acesso ao ControladorArmas

    public void EquiparArmaDisparoAlternado()
    {
        this.controladorArma.EquiparArmaDisparoAlternado();
    }

    public void EquiparArmaDisparoDuplo()
    {
        this.controladorArma.EquiparArmaDisparoDuplo();
    }

    public void EquiparArmaDisparoEspalhado() 
    {
        this.controladorArma.EquiparArmaDisparoEspalhado();
    }

    public void AtivandoEscudo() 
    {
        escudo.AtivarEscudo();
    } 
    
    public void DesativandoEscudo() 
    {
        escudo.DesativarEscudo();
    }

    private void VerificarLimiteDaTela() 
    { 
        Vector2 posicaoAtualJogador = this.transform.position; // Recebe a posi��o em tempo real do jogador na cena
        float metadeDaLargura = Largura / 2f; // Vari�veis para fazer o posicionamento da nave para impedir que a nave saia do limite da cam�ra
        float metadeDaAltura = Altura / 2f;

        Camera camera = Camera.main; // Vari�vel para a cam�ra principal
        Vector2 limiteInferiorEsquerdo = camera.ViewportToWorldPoint(Vector2.zero); // Recebe a posi��o do viewPort e converte para coordenadas 2d, junto com um array com posi��o (0,0)
        Vector2 limiteSuperiorDireito = camera.ViewportToWorldPoint(Vector2.one); // Recebe a posi��o do viewPort e converte para coordenadas 2d, junto com um array com posi��o (1,1)

        float pontoDeReferenciaLadoEsquerdo = posicaoAtualJogador.x - metadeDaLargura;
        float pontoDeReferenciaLadoDireito = posicaoAtualJogador.x + metadeDaLargura;

        // Verifica se o jogador saiu pela esquerda, analisando se a posi��o Horizontal � menor do que a posi��o Horizontal do Limite
        if (pontoDeReferenciaLadoEsquerdo < limiteInferiorEsquerdo.x) 
        {
            // Atualiza a posi��o horizontal do Player para a posi��o do Limite Esquerdo e manter a posi��o Vertical atual do Player
            // A soma faz com que, quando o pixel da nva sai do limite, seja somado metadeDaLargura da nave para voltar a mesma posi��o
            transform.position = new Vector2(limiteInferiorEsquerdo.x + metadeDaLargura, posicaoAtualJogador.y); 
        }
        else if (pontoDeReferenciaLadoDireito > limiteSuperiorDireito.x) // Verifica a saida pelo lado direito da cam�ra
        {
            transform.position = new Vector2(limiteSuperiorDireito.x - metadeDaLargura, posicaoAtualJogador.y);
        }
        
        posicaoAtualJogador = this.transform.position; // Atualiza a posi��o do jogador para verificar o superior e inferior porqu� houve mudan�a na posi��o da esquerda e na direita
        // Esss trecho permite que o Player n�o saia pela diagonal

        float pontoDeReferencialLadoSuperior = posicaoAtualJogador.y + metadeDaAltura;
        float pontoDeReferenciaLadoInferior = posicaoAtualJogador.y - metadeDaAltura;

        if (pontoDeReferencialLadoSuperior > limiteSuperiorDireito.y) // Verifica a saida pelo lado de cima da cam�ra
        {
            transform.position = new Vector2(posicaoAtualJogador.x, limiteSuperiorDireito.y - metadeDaAltura);
        }
        else if (pontoDeReferenciaLadoInferior < limiteInferiorEsquerdo.y) // Verifica a saida inferior da cam�ra
        {
            transform.position = new Vector2(posicaoAtualJogador.x, limiteInferiorEsquerdo.y + metadeDaAltura);
        }
    }

    public float Largura
    {
        get 
        { 
            Bounds bound = spriteRenderer.bounds; // Obt�m os limites de um spriteRenderer. Esse limite � uma caixa em torno do sprite
            Vector3 tamanhoHorizontalJogador = bound.size; // Retorna o tamanho de um sprite: Largura(Horizontal/X), Altura(Vertical/Y) e Rota��o(Z)
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

            if (vidas >= QuantidadeMaximaVida) // Verifica��o para impedir que o Jogador tenha mais do que o permitido
            { 
                vidas = QuantidadeMaximaVida;
            }
            else if (vidas <= 0) 
            { 
                vidas = 0;
                gameObject.SetActive(false); // Desativa o Inspector do Jogador
                controladorAudio.TocarSomDerrotaJogador();
                telaGamerOver.Exibir(); // Chama o m�todo para mostrar� a Tela de Gamer Over, pois a vida do Player zerou
            }
        }
    }

    // M�todo para analisar as colis�es do Jogador
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Compara se o Jogador colidiu com um GameObject com a Tag "Inimigo"
        if (collision.CompareTag("Inimigo")) 
        {            
            Inimigo inimigo = collision.GetComponent<Inimigo>();
            ColisaoInimigo(inimigo);

        }
        else if (collision.CompareTag("ItemVida")) // Verifica colis�o do Player com o item
        { 
            ItemVida itemVida = collision.GetComponent<ItemVida>(); // Acessa diretamente o Script ItemVida com todas as configura��es e dados
            ColetarItemVida(itemVida);
        }
        else if (collision.CompareTag("PowerUp")) 
        { 
            PowerUpColetavel powerUp = collision.GetComponent<PowerUpColetavel>();
            ColetarPowerUp(powerUp);
        }
    }    

    private void ColisaoInimigo(Inimigo inimigo) 
    {
        if (escudo.VerificarEscudoAtivo) 
        {
            controladorAudio.TocarSomDanoEscudo(); // Ativa o �udio
            escudo.ReceberDano();
        }
        else 
        {
            controladorAudio.TocarSomDanoJogador();
            Vida--; // Decrementa a vida pois h� um Set na Propriedade de Acesso        
        }
        
        inimigo.ReceberDano(); // Chama o m�todo do script inimigo para retirar ponto de vida o Inimigo com a colis�o entre o Player
    }

    private void ColetarItemVida(ItemVida itemVida)
    {
        Vida += itemVida.QuantidadeVida; // Incrementa a propriedade da vida do Player com a QuantidadeVida que o item recupera do usu�rio
        itemVida.ColetarItem(); // Chama o m�todo para destruir o item ap�s a colis�o com o Player
    }
    
    private void ColetarPowerUp(PowerUpColetavel powerUp) // Vari�vel para acessar a lista de powerUps
    { 
        if (powerUpAtual != null) 
        { // Remove o efeito caso haja algum efeito aplicado
            powerUpAtual.RemoverEfeito(this);
        }

        EfeitoPowerUp efeitoPowerUp = powerUp.EfeitoPowerUp; 
        efeitoPowerUp.AplicarEfeito(this); // Aplica o efeito no script do Jogador com o uso do This        
        powerUpAtual = efeitoPowerUp;
        powerUp.ColetarPowerUp();
    }
}