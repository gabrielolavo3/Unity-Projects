using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
    public Text textoPontuacao; // V�riavel que representa a o texto da pontuacao no Canva UI
    public BarraDeVida barraDeVida; // Vari�vel de acesso ao script/class BarraDeVida
    private NaveJogador jogador; // Vari�vel para ter a refer�ncia do jogador

    void Start()
    {
        // Usa a vari�vel de NaveJogador para buscar pela tag Player e trazer o componente do objeto
        jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<NaveJogador>();   
    }

    void Update()
    {
        // Atribuindo ao elemento text o Scrpit da pontua��o, chamando seu metodo e concatenando
        // O text retorna uma String
        textoPontuacao.text = ControladorPontuacao.Pontuacao + "x";

        // Acessa o script, chama o metodo ExibirVidas, passando a propriedade de acesso de NaveJogador
        barraDeVida.ExibirVidas(jogador.Vida);
    }
}
