using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pontuacao : MonoBehaviour
{
    private float tempo;
    private int pontuacao;
    [SerializeField] private TMP_Text pontuacaoText;
    [SerializeField] private TMP_Text pontuacaoGamerOverText;
    
    void Update()
    {
        tempo += Time.deltaTime;
        pontuacao = (int)(tempo * 5);

        pontuacaoText.text = pontuacao.ToString("000000");
        pontuacaoGamerOverText.text = pontuacao.ToString("000000");
    }
}