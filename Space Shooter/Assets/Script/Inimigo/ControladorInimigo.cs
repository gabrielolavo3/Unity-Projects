using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorInimigo : MonoBehaviour
{
    private float tempoDecorrido;
    [SerializeField] private float intervaloCriacaoInimigo;
    [SerializeField] private ConfiguracaoInimigo[] configuracaoInimigos;

    //public Inimigo inimigoPequenoPrefab; // Variável pública para receber o Sprite do Inimigo no Inspector
    //public Inimigo inimigoGrandePrefab;

    void Start()
    {
        tempoDecorrido = 0;
    }
    
    void Update()
    {
        // Time.deltaTime retorna o tempo entre cada frame
        tempoDecorrido += Time.deltaTime;

        if (tempoDecorrido >= intervaloCriacaoInimigo) 
        {
            // Criando um novo inimigo e zerando o tempo acumulado
            tempoDecorrido = 0;

            // Usando a posição da Main Camera para gerar inimigos no topo da tela
            Vector2 posicaoMaxima = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            Vector2 posicaoMinima = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            // Gera um número aleatório para o spaw do inimigo no eixo Horizontal da camêra, com base na posição Horizontal de posicaoMinima e posicaoMaxima
            float posicaoX = Random.Range(posicaoMinima.x, posicaoMaxima.x); 

            Vector2 posicaoInimigo = new Vector2(posicaoX, posicaoMaxima.y); // Defini o spaw do inimigo como um valor aleatório de posicaoX e mantendo o posição Vertical(Y) o objeto

            ConfiguracaoInimigo configuracaoInimigo = GetConfiguracaoInimigoAleatoria();
            Inimigo inimigoPrefab = configuracaoInimigo.InimigoPrefab; // Variável do tipo Inimigo para definir o prefab

            /*
            float chanceDeSpaw = Random.Range(0, 100f); // Chance aleatória de 0% a 100% de surgir

            if (chanceDeSpaw <= 25f)
            {
                // Caso tenha 25% de surgir, o sprite do inimigo será inimigoGrandePrefab
                inimigoPrefab = inimigoGrandePrefab; 
            }
            else 
            {
                // Senão, o sprite do inimigo será inimigoPequenoPrefab
                inimigoPrefab = inimigoPequenoPrefab;
            }
            */

            // Chama o inimigo novamente, passando o Sprite, posição e rotação padrão para 2D
            Inimigo novoInimigo = Instantiate(inimigoPrefab, posicaoInimigo, Quaternion.identity);
            novoInimigo.Configurar(configuracaoInimigo.PropriedadeInimigo);
        }
    }

    private ConfiguracaoInimigo GetConfiguracaoInimigoAleatoria()
    {
        if (configuracaoInimigos == null || configuracaoInimigos.Length == 0)
        {
            // Verifica se há inimigo em alguma posição
            return null;
        }

        int indiceAleatorio = Random.Range(0, configuracaoInimigos.Length); // Escolhe um indice aleatorio para a gerar um inimigo
        return configuracaoInimigos[indiceAleatorio];
    }
}
