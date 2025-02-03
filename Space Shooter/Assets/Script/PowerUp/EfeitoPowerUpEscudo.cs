using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoPowerUpEscudo : EfeitoPowerUp
{
    public EfeitoPowerUpEscudo(float duracaoEmSegundoss) : base(duracaoEmSegundoss)
    {

    }

    public override void AplicarEfeito(NaveJogador jogador)
    {
        jogador.AtivandoEscudo();
    }

    public override void RemoverEfeito(NaveJogador jogador)
    {
        jogador.DesativandoEscudo();
    }
}
