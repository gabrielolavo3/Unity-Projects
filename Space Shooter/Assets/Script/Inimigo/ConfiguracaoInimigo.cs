using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cria uma opçao de menu na Unity para usar o script do tipo ScriptableObject
[CreateAssetMenu(fileName = "Nova Configuração", menuName = "Space Shooter/Inimigo/Configuração Inimigo")]
public class ConfiguracaoInimigo : ScriptableObject
{
    // Script que serve para unir as caracteristicas de Inimgo e PropriedadeInimigo

    [SerializeField] private Inimigo inimigoPrefab;
    [SerializeField] private PropriedadeInimigo propriedadeInimigo;

    public Inimigo InimigoPrefab
    {
        get
        {
            return inimigoPrefab;
        }
    }

    public PropriedadeInimigo PropriedadeInimigo
    {
        get
        {
            return propriedadeInimigo;
        }
    }
}
