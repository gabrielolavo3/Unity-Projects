using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoDisparoAlternado : EfeitoPowerUp
{
    public EfeitoDisparoAlternado(float duracaoEmSegundoss) : base(duracaoEmSegundoss)
    {

    }

    public override void AplicarEfeito(NaveJogador jogador)
    {
        jogador.EquiparArmaDisparoAlternado();
    }

    public override void RemoverEfeito(NaveJogador jogador)
    {
        jogador.EquiparArmaDisparoAlternado();
    }
}
