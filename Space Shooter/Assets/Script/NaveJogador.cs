using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveJogador : MonoBehaviour
{
    public new Rigidbody2D rigidbody; // Atributo do tipo Rigidbody2D para Fisica2D
    public Laser laserPrefab; // variável para indicar o Sprite do Laser no Inspector
    public float velocidadeMovimento; // Variável para inserir o valor no Inspector
    public float tempoDeEsperaDotiro;
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
        ControladorPontuacao.Pontuacao = 0;
        vidas = 5;        
        GameObject gamerOverObject = GameObject.FindGameObjectWithTag("Gamer Over"); // Variável GameObject para buscar o 1º GameObject com a Tag "Gamer Over"        
        telaGamerOver = gamerOverObject.GetComponent<GamerOver>(); // Variável do tipo GamerOver recebendo o GameObject com a Tag e buscando o componente
        telaGamerOver.EsconderTela(); // Chama metodo para desativar a tela de GamerOver no inicio do Play
    }

    // Update é chamado a cada frame
    void Update()
    {
        intervaloTiro += Time.deltaTime;

        if (intervaloTiro >= tempoDeEsperaDotiro)
        {
            intervaloTiro = 0;
            Atirar();
        }

        float horizontal = Input.GetAxis("Horizontal"), // Recebe o clique das teclas A e D, do eixo horizontal
              vertical = Input.GetAxis("Vertical"), // Recebe o clique das teclas W e S, do eixo vertical
              velocidadeX = horizontal * this.velocidadeMovimento,
              velocidadeY = vertical * this.velocidadeMovimento;

        this.rigidbody.velocity = new Vector2(velocidadeX, velocidadeY); // Acessa a propriedade velocity de Rigidbody2D e passar um new Vector2 que recebe a posicao X e Y
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

    // Método para a colisão
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo")) 
        {
            Vida--; // Decrementa a vida pois há um Set na Propriedade de Acesso
            Debug.Log("Vida atual " + Vida);
            Inimigo inimigo = collision.GetComponent<Inimigo>();
            inimigo.ReceberDano();
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
