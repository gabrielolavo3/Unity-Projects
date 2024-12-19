using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaDisparoDuplo : ArmaBasica
{
    protected override void Atirar()
    {
        // Sobreescreve o método Atirar() e chama o método CriarLaser(), ativando as duas posições do array para fazer o disparo nos 2 GameObject
        CriarLaser(posicaoDisparo[0].position);
        CriarLaser(posicaoDisparo[1].position);
    }  
}
