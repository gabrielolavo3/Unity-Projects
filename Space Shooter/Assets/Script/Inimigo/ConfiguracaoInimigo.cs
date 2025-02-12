using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cria uma op�ao de menu na Unity para usar o script do tipo ScriptableObject
[CreateAssetMenu(fileName = "Nova Configura��o", menuName = "Space Shooter/Inimigo/Configura��o Inimigo")]
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
