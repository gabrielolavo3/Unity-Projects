using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
    public Text textoPontuacao; // Váriavel que representa a o texto da pontuacao no Canva UI
    public BarraDeVida barraDeVida; // Variável de acesso ao script/class BarraDeVida
    private NaveJogador jogador; // Variável para ter a referência do jogador

    void Start()
    {
        // Usa a variável de NaveJogador para buscar pela tag Player e trazer o componente do objeto
        jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<NaveJogador>();   
    }

    void Update()
    {
        // Atribuindo ao elemento text o Scrpit da pontuação, chamando seu metodo e concatenando
        // O text retorna uma String
        textoPontuacao.text = ControladorPontuacao.Pontuacao + "x";

        // Acessa o script, chama o metodo ExibirVidas, passando a propriedade de acesso de NaveJogador
        barraDeVida.ExibirVidas(jogador.Vida);
    }
}
