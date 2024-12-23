using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoDisparoAlternado : EfeitoPowerUp
{
    public override void AplicarEfeito(NaveJogador jogador)
    {
        jogador.EquiparArmaDisparoAlternado();
    }
}
