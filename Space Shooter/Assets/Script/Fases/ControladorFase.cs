using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorFase : MonoBehaviour
{

    [SerializeField] private Fase[] fase;
    [SerializeField] private ControladorInimigo controladorInimigo;
    private int indiceFaseAtual;
    private Fase faseAtual;
    
    void Start()
    {
        indiceFaseAtual = 0;
        IniciarFaseAtual();
    }

    public void ConcluirFase()
    {
        if (TemProximaFase())
        {
            Debug.Log("Fase " + faseAtual.Nome + " foi concluída. Avançando para a próxima fase...");
            indiceFaseAtual++;
            IniciarFaseAtual();
        }
        else
        {
            Debug.Log("Fim de jogo. Todas as fases foram concluídas");
        }
    }

    public bool TemProximaFase()
    {
        // Usa o indice atual da fase e compara com o valor do array para saber se há mais fases
        if (indiceFaseAtual < fase.Length - 1)
        {
            return true;
        }

        return false;
    }

    public void IniciarFaseAtual()
    {
        faseAtual = fase[indiceFaseAtual]; // Saber a fase atual do jogo
        controladorInimigo.Configurar(this, faseAtual.ConfiguracaoControladorInimigo);
    }

   
}
