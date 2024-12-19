using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ControladorPontuacao 
{
    private static int pontuacao;

    // Método getter e setter
    public static int Pontuacao
    {
        get 
        { 
            return pontuacao;
        }

        set 
        { 
            pontuacao = value;
            if ( pontuacao < 0) 
            {
                pontuacao = 0;
            }

            Debug.Log("Pontuação atualizada para: " + Pontuacao);

            // Verifica se a pontuação atual é maior do que a antiga e atualiza a propriedade para receber a maior pontuação 
            if (pontuacao > MelhorPontuacao) 
            { 
                MelhorPontuacao = pontuacao; // Usa o set de MelhorPontuacao para mudar o valor do Value
            }
        }
    }

    // Propriedade Get e Set para obter a melhor pontuação do usuário
    public static int MelhorPontuacao 
    {
        get 
        {
            // Propriedade Get para buscar a pontuação atual do Player com PlayerPrefs, passando a Chave (identificador de onde está a pontuação)
            // E o valor de retorno caso não haja valor salvo no dispositivo do usuário
            int melhorPontuacao = PlayerPrefs.GetInt("melhorPontuacao", 0);
            return melhorPontuacao;
        }

        set 
        { 
            // Varifica se o value do Set, ou seja, o novo valor da Propriedade é maior do que o valor antigo do Get
            if (value > MelhorPontuacao) 
            {
                PlayerPrefs.SetInt("melhorPontuacao", value); // Se for, usa o PlayerPrefs, salvando um Int na chave e passando o novo valor com 2º parâmetro
            }
        }
    }
}
