using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoPowerUpEscudo : EfeitoPowerUp
{
    public override void AplicarEfeito(NaveJogador jogador)
    {
        jogador.AtivandoEscudo();
    }
}
