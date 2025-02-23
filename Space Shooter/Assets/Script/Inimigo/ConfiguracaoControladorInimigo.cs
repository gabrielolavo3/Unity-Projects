using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova Configura��o", menuName = "Space Shooter/Inimigo/Configura��o Controlador Inimigo")]
public class ConfiguracaoControladorInimigo : ScriptableObject
{
    // Script usado para cria��o de fases, serve para separar a configuracao de inimigos de uma fase
    [SerializeField] private float intervaloCriacaoInimigo;
    [SerializeField] private ConfiguracaoInimigo[] configuracaoInimigos;
    [SerializeField] private int quantidadeMaximaInimigo;

    public ConfiguracaoInimigo[] ConfiguracaoInimigos
    {
        get
        {
            return configuracaoInimigos;
        }
    }

    public float IntervaloCriacaoInimigo
    {
        get
        {
            return intervaloCriacaoInimigo;
        }
    }

    public int QuantidadeMaximaInimigo
    {
        get
        {
            return quantidadeMaximaInimigo;
        }
    }

}
