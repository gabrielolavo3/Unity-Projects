using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ControladorPontuacao 
{
    private static int pontuacao;

    // M�todo getter e setter
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

            Debug.Log("Pontua��o atualizada para: " + Pontuacao);

            // Verifica se a pontua��o atual � maior do que a antiga e atualiza a propriedade para receber a maior pontua��o 
            if (pontuacao > MelhorPontuacao) 
            { 
                MelhorPontuacao = pontuacao; // Usa o set de MelhorPontuacao para mudar o valor do Value
            }
        }
    }

    // Propriedade Get e Set para obter a melhor pontua��o do usu�rio
    public static int MelhorPontuacao 
    {
        get 
        {
            // Propriedade Get para buscar a pontua��o atual do Player com PlayerPrefs, passando a Chave (identificador de onde est� a pontua��o)
            // E o valor de retorno caso n�o haja valor salvo no dispositivo do usu�rio
            int melhorPontuacao = PlayerPrefs.GetInt("melhorPontuacao", 0);
            return melhorPontuacao;
        }

        set 
        { 
            // Varifica se o value do Set, ou seja, o novo valor da Propriedade � maior do que o valor antigo do Get
            if (value > MelhorPontuacao) 
            {
                PlayerPrefs.SetInt("melhorPontuacao", value); // Se for, usa o PlayerPrefs, salvando um Int na chave e passando o novo valor com 2� par�metro
            }
        }
    }
}
