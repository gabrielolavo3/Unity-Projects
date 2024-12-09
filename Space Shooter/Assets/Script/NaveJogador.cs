using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveJogador : MonoBehaviour
{
    public new Rigidbody2D rigidbody; // Atributo do tipo Rigidbody2D para Fisica2D
    public Laser laserPrefab; // vari�vel para indicar o Sprite do Laser no Inspector
    public float velocidadeMovimento; // Vari�vel para inserir o valor no Inspector
    public float tempoDeEsperaDotiro;
    private float intervaloTiro;
    public Transform[] posicaoArma; // Array para obter o position de cada arma
    private Transform armaAtual;
    private int vidas;
    private GamerOver telaGamerOver;

    // Start � chamado uma �nica vez antes do primeiro frame
    void Start()
    {
        Debug.Log("Imprimindo no console da Unity e usando o m�todo Start");
        intervaloTiro = 0;
        armaAtual = posicaoArma[0]; // Defini a posi��o da 1� arma
        ControladorPontuacao.Pontuacao = 0;
        vidas = 5;        
        GameObject gamerOverObject = GameObject.FindGameObjectWithTag("Gamer Over"); // Vari�vel GameObject para buscar o 1� GameObject com a Tag "Gamer Over"        
        telaGamerOver = gamerOverObject.GetComponent<GamerOver>(); // Vari�vel do tipo GamerOver recebendo o GameObject com a Tag e buscando o componente
        telaGamerOver.EsconderTela(); // Chama metodo para desativar a tela de GamerOver no inicio do Play
    }

    // Update � chamado a cada frame
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
                telaGamerOver.Exibir(); // Chama o m�todo para mostrar� a Tela de Gamer Over, pois a vida do Player zerou
            }
        }
    }

    // M�todo para a colis�o
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo")) 
        {
            Vida--; // Decrementa a vida pois h� um Set na Propriedade de Acesso
            Debug.Log("Vida atual " + Vida);
            Inimigo inimigo = collision.GetComponent<Inimigo>();
            inimigo.ReceberDano();
        }
    }

    private void Atirar() 
    {
        // Cria uma inst�ncia do Prefab do laser, na posi��o atual do array da arma
        Instantiate(laserPrefab, armaAtual.position, Quaternion.identity);

        // Realizando mudan�a de uso da arma de disparo, entre arma 1 e 2
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
