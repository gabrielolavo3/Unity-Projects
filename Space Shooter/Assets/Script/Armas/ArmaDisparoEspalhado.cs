using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaDisparoEspalhado : ArmaBasica
{
    [SerializeField, Range(0f, 30f)] private float anguloEntreDisparo;
    [SerializeField, Range(0, 30)] private int quantidadeDisparos;    

    protected override void Atirar()
    {
        Vector2 posicaoDisparoAtual = posicaoDisparo[0].position;

        for (int i = 0; i < quantidadeDisparos; i++)
        {            
            Laser laser = CriarLaser(posicaoDisparoAtual);
            laser.Direcao = CalcularDirecaoDisparo(i);
        }
    }

    private Vector2 CalcularDirecaoDisparo(int indice)
    {
        int indiceDisparoArco;

        if ((quantidadeDisparos % 2) == 0) 
        {
            indiceDisparoArco = indice + 1;  
        }
        else
        {
            indiceDisparoArco = indice;
        }

        indiceDisparoArco = Mathf.CeilToInt(indiceDisparoArco / 2f);

        float angulo = (anguloEntreDisparo * indiceDisparoArco);

        if ((indice % 2) != 0)
        {
            angulo *= -1;
        }

        Quaternion rotacao = Quaternion.AngleAxis(angulo, Vector3.forward);

        Vector2 direcao = rotacao * Vector3.up;
        return direcao;
    }
}
