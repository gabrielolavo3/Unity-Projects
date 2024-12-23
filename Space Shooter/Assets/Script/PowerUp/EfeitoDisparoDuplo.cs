using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoDisparoDuplo : EfeitoPowerUp
{
    public override void AplicarEfeito(NaveJogador jogador)
    {
        // Acessa o script do Jogador e mudar o uso da arma
        jogador.EquiparArmaDisparoDuplo();
    }
}
