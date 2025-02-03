using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EfeitoPowerUp
{
    private float duracaoPowerUp; // Defini por quanto tempo o efeito vai ficar ativo

    public EfeitoPowerUp (float duracaoEmSegundoss) 
    { 
        duracaoPowerUp = duracaoEmSegundoss;
    }

    // Método para aplicar o Efeito no script do Jogador
    public abstract void AplicarEfeito(NaveJogador jogador);
    
    public abstract void RemoverEfeito(NaveJogador jogador);

    public void AtualizarTempo() 
    { 
        if (VerificarAtivo) // Chama a propriedade, verificar se o retorno é true e decrementa o tempo do efeito com o tempo passado em cada frame
        {
            duracaoPowerUp -= Time.deltaTime;
            Debug.Log("Tempo restante: " + duracaoPowerUp);
        }        
    }

    public bool VerificarAtivo 
    {
        get 
        {
            bool duracao = duracaoPowerUp > 0 ? true : false;
            return duracao;
        }
    }
}
