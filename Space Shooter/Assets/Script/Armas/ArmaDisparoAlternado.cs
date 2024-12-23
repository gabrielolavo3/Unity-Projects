using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaDisparoAlternado : ArmaBasica // Uso de herança (POO C#)
{
    private Transform posicaoProximoDisparo;

    public override void Start() // Sobreescrita de método Start da classe abstrata
    {
        base.Start(); // Executa a lógica do Start da superclass e depois volta para implementar o código da class ArmaDisparoAlternado
        posicaoProximoDisparo = posicaoDisparo[0];
    }

    protected override void Atirar() // Sobreescrita de método da classe abstrata
    {
        // Chamada de método que cria instância do laser, passando a posição atual da variável posicaoProximoDisparo
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
