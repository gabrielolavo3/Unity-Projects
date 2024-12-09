using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveJogador : MonoBehaviour
{
    public new Rigidbody2D rigidbody; // Atributo do tipo Rigidbody2D para Fisica2D
    public Laser laserPrefab; // variável para indicar o Sprite do Laser no Inspector
    public float velocidadeMovimento; // Variável para inserir o valor no Inspector
    public float tempoDeEsperaDotiro; // Variável para inserir o valor no Inspector
    private float intervaloTiro;
    public Transform[] posicaoArma; // Array para obter o position de cada arma
    private Transform armaAtual;
    private int vidas;
    private GamerOver telaGamerOver;

    // Start é chamado uma única vez antes do primeiro frame
    void Start()
    {
        Debug.Log("Imprimindo no console da Unity e usando o método Start");
        intervaloTiro = 0;
        armaAtual = posicaoArma[0]; // Defini a posição da 1ª arma
        ControladorPontuacao.Pontuacao = 0; // Define a pontuação para 0 ao iniciar o jogo
        vidas = 5;        
        GameObject gamerOverObject = GameObject.FindGameObjectWithTag("Gamer Over"); // Variável GameObject para buscar o 1º GameObject com a Tag "Gamer Over"        
        telaGamerOver = gamerOverObject.GetComponent<GamerOver>(); // Variável do tipo GamerOver recebendo o GameObject com a Tag e buscando o componente
        telaGamerOver.EsconderTela(); // Chama metodo para desativar a tela de GamerOver no inicio do Play
    }

    // Update é chamado a cada frame
    void Update()
    {
        // Adiciona o tempo passado na Unity
        intervaloTiro += Time.deltaTime;

        // Analisa se o tempo de intervaloTiro é maior do que tempoDeEsperaDotiro(definido no inspecto)
        if (intervaloTiro >= tempoDeEsperaDotiro)
        {
            // Zera o intervaloTiro e chama o método atirar, que irá mudar a posição a arma a cada chamada do Update
            intervaloTiro = 0;
            Atirar();
        }

        float horizontal = Input.GetAxis("Horizontal"), // Recebe o clique das teclas A e D, do eixo horizontal
              vertical = Input.GetAxis("Vertical"), // Recebe o clique das teclas W e S, do eixo vertical
              velocidadeX = horizontal * this.velocidadeMovimento,
              velocidadeY = vertical * this.velocidadeMovimento;

        this.rigidbody.velocity = new Vector2(velocidadeX, velocidadeY); // Acessa a propriedade velocity de Rigidbody2D e passar um new Vector2 que recebe a posicao X e Y
    }

    private void VerificarLimiteDaTela() 
    { 
        Vector2 posicaoAtualJogador = this.transform.position; // Recebe a posição em tempo real do jogador na cena

        Camera camera = Camera.main; // Variável para a camêra principal
        Vector2 limiteInferiorEsquerdo = camera.ViewportToWorldPoint(Vector2.zero); // Recebe a posição do viewPort e converte para coordenadas 2d, junto com um array com posição (0,0)
        Vector2 limiteSuperiorDireito = camera.ViewportToWorldPoint(Vector2.one); // Recebe a posição do viewPort e converte para coordenadas 2d, junto com um array com posição (1,1)

        // Verifica se o jogador saiu pela esquerda, analisando se a posição Horizontal é menor do que a posição Horizontal do Limite
        if (posicaoAtualJogador.x < limiteInferiorEsquerdo.x) 
        {
            // Atualiza a posição horizontal do Player para a posição do Limite Esquerdo e manter a posição Vertical atual do Player
            transform.position = new Vector2(limiteInferiorEsquerdo.x, posicaoAtualJogador.y);
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
            if (vidas <= 0) 
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
    }

    private void Atirar() 
    {
        // Cria uma instância do Prefab do laser, na posição atual do array da arma
        Instantiate(laserPrefab, armaAtual.position, Quaternion.identity);

        // Realizando mudança de uso da arma de disparo, entre arma 1 e 2
        if (armaAtual == posicaoArma[0]) 
        {
            armaAtual = posicaoArma[1];
        }
        else
        {
            armaAtual = posicaoArma[0];
        }
    }
}
