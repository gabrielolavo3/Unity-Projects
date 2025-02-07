using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVida : MonoBehaviour
{
    [SerializeField] private int quantidadeVida; // SerializeField permite que variáveis privadas sejam acessivéis no inspecto da Unity
    [SerializeField] private ParticleSystem particulaItemVidaPrefab; // Variável do tipo do Sistema de Particulas da Unity

    public int QuantidadeVida
    {
        get 
        { 
            return quantidadeVida;
        }
    }

    public void ColetarItem()
    {
        ControladorAudio controladorAudio = GameObject.FindObjectOfType<ControladorAudio>();
        controladorAudio.TocarSomVidaColetada();

        // Instancia, exibe e destrói a particula
        ParticleSystem part = Instantiate(particulaItemVidaPrefab, transform.position, Quaternion.identity);
        Destroy(part.gameObject, 1f);

        // Destrói o GameObject do item automaticamente
        Destroy(gameObject);
    }
}
