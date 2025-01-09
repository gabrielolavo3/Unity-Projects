using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpColetavel : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float intervaloTempoAntesAutodestruicao; // Defini quanto tempo deve passar antes de iniciar a autodestrui��o
    [SerializeField] private int quantidadeTotalDePiscadas; // Defini quantas vezes o Sprite do PowerUp ir� piscar antes da desaparecer
    [SerializeField] private float intervaloTempoEntrePiscadas; // Defini o tempo total para implementar todas as piscadas
    [SerializeField] private float reducaoTempoEntrePiscadas;
    private float contagemTempoAntesAutodestruicao; // Valor para verificar quanto tempo passou para come�ar a autodestrui��o
    private bool autodestruindo;

    // Defini qual a regrar que todo PowerUp deve implementar
    public abstract EfeitoPowerUp EfeitoPowerUp
    {
        get;
    }

    private void Start()
    {
        autodestruindo = false;
        contagemTempoAntesAutodestruicao = 0;
    }

    private void Update()
    {
        if (!this.autodestruindo) // Caso n�o esteja audestruindo
        { 
            contagemTempoAntesAutodestruicao += Time.deltaTime; // Inicia a contagem para ativar a autodestrui��o do PowerUp
            if (contagemTempoAntesAutodestruicao >= intervaloTempoAntesAutodestruicao) // Analisa se a contagem de tempo que passou � igual ao tempo definido para iniciar a autodestrui��o
            {
                IniciarAudestruicao();
            }
        }
    }

    public void ColetarPowerUp() 
    { 
        Destroy(gameObject); // Destroi o PowerUp
    }

    private void IniciarAudestruicao() 
    {
        autodestruindo = true;
        StartCoroutine(Autodestruir()); // Uso de Coroutina: Cria uma execu��o em parelelo sem parar o fluxo de tempo normal do jogo
    }

    private IEnumerator Autodestruir() // Tipo de m�todo que permite usar o recurso de esperar um tempo de execu��o do c�digo
    {
        int contador = 0;

        do
        {
            // Condicional para ativar e desativar o SpriteRenderer do PowerUp
            if (spriteRenderer.enabled) // Enabled retornar se um sprite est� ativado
            {
                spriteRenderer.enabled = false;
            }
            else
            {
                spriteRenderer.enabled = true;
            }

            yield return new WaitForSeconds(intervaloTempoEntrePiscadas); // Retornar um tempo em segundos e pausa a execu��o para depois seguir a execu��o 
            contador++;
            intervaloTempoEntrePiscadas -= contador * reducaoTempoEntrePiscadas; 
        
        } while (contador < quantidadeTotalDePiscadas);

        Destroy(gameObject);
    }
}
