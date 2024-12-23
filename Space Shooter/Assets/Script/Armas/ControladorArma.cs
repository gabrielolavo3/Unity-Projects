using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorArma : MonoBehaviour
{
    [SerializeField] private ArmaDisparoAlternado armaDisparoAlternado;
    [SerializeField] private ArmaDisparoDuplo armaDisparoDuplo;
    private ArmaBasica armaAtual;

    private void Awake() // O Awake � executado antes de qualquer Start. � necess�rio para desativar as armas antes da execu��o dos Starts
    {
        this.armaDisparoAlternado.Desativar();
        this.armaDisparoDuplo.Desativar();
    }

    public void EquiparArmaDisparoAlternado() 
    {
        this.ArmaAtual = this.armaDisparoAlternado;
    }

    public void EquiparArmaDisparoDuplo()
    {
        this.ArmaAtual = this.armaDisparoDuplo;
    }

    public ArmaBasica ArmaAtual
    {
        set 
        { 
            if (armaAtual != null) // Verifica h� alguma arma equipada e desativa seu uso
            {
                armaAtual.Desativar();
            }
            armaAtual = value; // Atualiza a arma equipada e ativa seu uso
            armaAtual.Ativar();
        }
    }   
}
