using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
    public Text textoPontuacao; // V�riavel que representa a o texto da pontuacao no Canva UI
    
    void Update()
    {
        // Atribuindo ao elemento text o Scrpit da pontua��o, chamando seu metodo e concatenando
        // O text retorna uma String
        textoPontuacao.text = ControladorPontuacao.Pontuacao + "x";
    }
}
