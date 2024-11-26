using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
    public Text textoPontuacao; // Váriavel que representa a o texto da pontuacao no Canva UI
    
    void Update()
    {
        // Atribuindo ao elemento text o Scrpit da pontuação, chamando seu metodo e concatenando
        // O text retorna uma String
        textoPontuacao.text = ControladorPontuacao.Pontuacao + "x";
    }
}
