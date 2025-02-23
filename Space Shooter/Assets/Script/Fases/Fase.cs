using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script que representa a configuração de uma fase
[CreateAssetMenu(fileName = "Nova fase", menuName = "Space Shooter/Fases/Nova fase")]
public class Fase : ScriptableObject
{
    [SerializeField] private string nome;
    [SerializeField] private ConfiguracaoControladorInimigo configuracaoControladorInimigo;

    public string Nome
    {        
        get 
        {
            return nome;
        }
    }

    public ConfiguracaoControladorInimigo ConfiguracaoControladorInimigo
    {
        get
        {
            return configuracaoControladorInimigo;
        }
    }
}
