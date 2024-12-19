using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Bibilioteca para acessar o Canvas UI e o Text
using UnityEngine.SceneManagement; // Biblioteca que controla as cenas da Unity

public class GamerOver : MonoBehaviour
{
    public Text textoPontuacaoFinal;
    public Text textoMelhorPontuacao;
    
    public void Exibir() 
    { 
        gameObject.SetActive(true); // Ativa o gameObject que o Script está conectado = GamerOver
        textoPontuacaoFinal.text = ControladorPontuacao.Pontuacao + "x";
        textoMelhorPontuacao.text = ControladorPontuacao.MelhorPontuacao.ToString(); // Exibir a melhor pontuação na interface e converte para um String        

        Time.timeScale = 0; // Pausa o tempo da Unity
    }

    public void EsconderTela() 
    {
        // Metodo para desativar a tela de GamerOver no inicio do Play
        gameObject.SetActive(false);
    }
    public void TentarNovamente() 
    {        
        Time.timeScale = 1.0f; // Faz o tempo voltar a funcionar na Unity
        SceneManager.LoadScene("Fase01"); // Chama o controlador de cenas(SceneManager), usando o LoadScene e passando o nome da cena pra transição(Id ou Nome)
    }
}
