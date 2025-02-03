using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoDisparoEspalhado : EfeitoPowerUp
{
    public EfeitoDisparoEspalhado(float duracaoEmSegundoss) : base(duracaoEmSegundoss)
    {

    }

    public override void AplicarEfeito(NaveJogador jogador)
    {
        jogador.EquiparArmaDisparoEspalhado();
    }

    public override void RemoverEfeito(NaveJogador jogador)
    {
        jogador.EquiparArmaDisparoAlternado();
    }
}
