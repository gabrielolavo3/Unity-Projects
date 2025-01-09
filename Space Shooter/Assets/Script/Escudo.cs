using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Quantidade de dano que pode ser recebido pelo escudo, antes de desativar")]
    private int protecaoTotal;
    private int protecaoAtual; // Quantidade de dano que o escudo ainda pode receber

    public void AtivarEscudo() 
    {
        protecaoAtual = protecaoTotal;
        gameObject.SetActive(true);
    }

    public void DesativarEscudo()
    {
        gameObject.SetActive(false);
    }

    public bool VerificarEscudoAtivo 
    { 
        get 
        {
            return gameObject.activeSelf;
        }
    }

    public void ReceberDano() 
    {
        protecaoAtual--;

        if (protecaoAtual <= 0) 
        { 
            DesativarEscudo();
        }
    }
}
