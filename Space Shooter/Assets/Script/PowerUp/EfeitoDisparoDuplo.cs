using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoDisparoDuplo : EfeitoPowerUp
{
    public EfeitoDisparoDuplo(float duracaoEmSegundos) : base(duracaoEmSegundos) 
    { 
        
    }

    public override void AplicarEfeito(NaveJogador jogador)
    {
        // Acessa o script do Jogador e mudar o uso da arma
        jogador.EquiparArmaDisparoDuplo();
    }

    public override void RemoverEfeito(NaveJogador jogador)
    {
        jogador.EquiparArmaDisparoAlternado();
    }
}
