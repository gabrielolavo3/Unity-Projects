using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorInimigo : MonoBehaviour
{
    private float tempoDecorrido;
    public Inimigo inimigoPequenoPrefab; // Vari�vel p�blica para receber o Sprite do Inimigo no Inspector
    public Inimigo inimigoGrandePrefab;

    void Start()
    {
        tempoDecorrido = 0;
    }
    
    void Update()
    {
        // Time.deltaTime retorna o tempo entre cada frame
        tempoDecorrido += Time.deltaTime;

        if (tempoDecorrido >= 1f) 
        {
            // Criando um novo inimigo e zerando o tempo acumulado
            tempoDecorrido = 0;

            // Usando a posi��o da Main Camera para gerar inimigos no topo da tela
            Vector2 posicaoMaxima = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            Vector2 posicaoMinima = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            // Gera um n�mero aleat�rio para o spaw do inimigo no eixo Horizontal da cam�ra, com base na posi��o Horizontal de posicaoMinima e posicaoMaxima
            float posicaoX = Random.Range(posicaoMinima.x, posicaoMaxima.x); 

            Vector2 posicaoInimigo = new Vector2(posicaoX, posicaoMaxima.y); // Defini o spaw do inimigo como um valor aleat�rio de posicaoX e mantendo o posi��o Vertical(Y) o objeto

            Inimigo inimigoPrefab; // Vari�vel do tipo Inimigo para definir o prefab
            float chanceDeSpaw = Random.Range(0, 100f); // Chance aleat�ria de 0% a 100% de surgir

            if (chanceDeSpaw <= 25f)
            {
                // Caso tenha 25% de surgir, o sprite do inimigo ser� inimigoGrandePrefab
                inimigoPrefab = inimigoGrandePrefab; 
            }
            else 
            {
                // Sen�o, o sprite do inimigo ser� inimigoPequenoPrefab
                inimigoPrefab = inimigoPequenoPrefab;
            }

            // Chama o inimigo novamente, passando o Sprite, posi��o e rota��o padr�o para 2D
            Instantiate(inimigoPrefab, posicaoInimigo, Quaternion.identity);
        }
    }
}
