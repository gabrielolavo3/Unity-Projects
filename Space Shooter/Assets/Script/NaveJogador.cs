using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveJogador : MonoBehaviour
{
    public new Rigidbody2D rigidbody; // Atributo do tipo Rigidbody2D para Fisica2D
    public Laser laserPrefab;
    public float velocidadeMovimento;
    public float tempoDeEsperaDotiro;
    private float intervaloTiro;
    public Transform[] posicaoArma; // Array para obter o position de cada arma
    private Transform armaAtual;
    private int vidas;

    // Start é chamado uma única vez antes do primeiro frame
    void Start()
    {
        Debug.Log("Imprimindo no console da Unity e usando o método Start");
        intervaloTiro = 0;
        armaAtual = posicaoArma[0];
        ControladorPontuacao.Pontuacao = 0;
        vidas = 5;
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

        float horizontal = Input.GetAxis("Horizontal"),
              vertical = Input.GetAxis("Vertical"),
              velocidadeX = horizontal * this.velocidadeMovimento,
              velocidadeY = vertical * this.velocidadeMovimento;

        this.rigidbody.velocity = new Vector2(velocidadeX, velocidadeY);
    }

    public int Vida
    {
        get
        {
            return vidas;
        }

        set 
        {
            this.vidas = value;
            if (vidas < 0) 
            { 
                vidas = 0;
            }
        }
    }

    // Método para a colisão
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo")) 
        {
            Vida--;
            Debug.Log("Vida atual " + Vida);
            Inimigo inimigo = collision.GetComponent<Inimigo>();
            inimigo.Destuir(false);
        }
    }

    private void Atirar() 
    {
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
