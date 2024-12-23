using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaDisparoAlternado : ArmaBasica // Uso de heran�a (POO C#)
{
    private Transform posicaoProximoDisparo;

    public override void Start() // Sobreescrita de m�todo Start da classe abstrata
    {
        base.Start(); // Executa a l�gica do Start da superclass e depois volta para implementar o c�digo da class ArmaDisparoAlternado
        posicaoProximoDisparo = posicaoDisparo[0];
    }

    protected override void Atirar() // Sobreescrita de m�todo da classe abstrata
    {
        // Chamada de m�todo que cria inst�ncia do laser, passando a posi��o atual da vari�vel posicaoProximoDisparo
        CriarLaser(posicaoProximoDisparo.position);

        // Alternando o uso da arma
        if (posicaoProximoDisparo == posicaoDisparo[0])
        {
            posicaoProximoDisparo = posicaoDisparo[1];
        }
        else 
        {
            posicaoProximoDisparo = posicaoDisparo[0];
        }
    }
}
