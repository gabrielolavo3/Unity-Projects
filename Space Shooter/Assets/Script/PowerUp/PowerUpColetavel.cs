using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpColetavel : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;    
    [SerializeField] private int quantidadeTotalDePiscadas; // Defini quantas vezes o Sprite do PowerUp irá piscar antes da desaparecer
    [SerializeField] private float intervaloTempoEntrePiscadas; // Defini o tempo total para implementar todas as piscadas
    [SerializeField] private float intervaloTempoAntesAutodestruicao; // Defini quanto tempo deve passar antes de iniciar a autodestruição
    private float contagemTempoAntesAutodestruicao; // Valor para verificar quanto tempo passou para começar a autodestruição
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
        if (autodestruindo) 
        { 
            contagemTempoAntesAutodestruicao += Time.deltaTime; // Inicia a contagem para ativar a autodestruição do PowerUp
            if (contagemTempoAntesAutodestruicao >= intervaloTempoAntesAutodestruicao) // Analisa se a contagem de tempo que passou é igual ao tempo definido para iniciar a autodestruição
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
        StartCoroutine(Autodestruir()); // Uso de Coroutina: Cria uma execução em parelelo sem parar o fluxo de tempo normal do jogo
    }

    private IEnumerator Autodestruir() // Tipo de método que permite usar o recurso de esperar um tempo de execução do código
    {
        int contador = 0;

        do
        {
            // Condicional para ativar e desativar o SpriteRenderer do PowerUp
            if (spriteRenderer.enabled == true)
            {
                spriteRenderer.enabled = false;
            }
            else
            {
                spriteRenderer.enabled = true;
            }

            yield return new WaitForSeconds(intervaloTempoEntrePiscadas); // Pausa de execução por um tempo em segundos

            contador++;
        }
        while (contador < quantidadeTotalDePiscadas);

        Destroy(gameObject);
    }
}
