using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorInimigo : MonoBehaviour
{
    private ConfiguracaoControladorInimigo configuracaoControladorInimigo;
    private float tempoDecorrido;
    private bool criacaoInimigosConcluida;
    private int quantidadeInimigosCriados; // Soma a quantidade total de inimigos criados
    private List<Inimigo> inimigos;
    private ControladorFase controladorFase;
    //public Inimigo inimigoPequenoPrefab; // Variável pública para receber o Sprite do Inimigo no Inspector
    //public Inimigo inimigoGrandePrefab;

    void Update()
    {
        // Time.deltaTime retorna o tempo entre cada frame
        tempoDecorrido += Time.deltaTime;

        if (criacaoInimigosConcluida)
        {
            return;
        }

        if (tempoDecorrido >= configuracaoControladorInimigo.IntervaloCriacaoInimigo) 
        {
            // Criando um novo inimigo e zerando o tempo acumulado
            tempoDecorrido = 0;
            quantidadeInimigosCriados++;
            CriarInimigo();           

            // Verifica se a quantidade de inimigos já está no limite e para a geração, mudando o valor bool para o próximo update
            if (quantidadeInimigosCriados >= configuracaoControladorInimigo.QuantidadeMaximaInimigo)
            {
                criacaoInimigosConcluida = true;
            }

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
        }
    }

    // Método usado para ControladorFase
    public void Configurar(ControladorFase controladorFase, ConfiguracaoControladorInimigo configuracaoControlador)
    {
        this.controladorFase = controladorFase;
        this.configuracaoControladorInimigo = configuracaoControlador;

        criacaoInimigosConcluida = false;
        quantidadeInimigosCriados = 0;
        tempoDecorrido = 0;
        inimigos = new List<Inimigo>();
    }

    // Acessa o script do inimigo e verifica se há um inimigo na lista e o removi
    public void RemoverInimigo(Inimigo inimigo)
    {
        if (inimigos.Contains(inimigo))
        {
            inimigos.Remove(inimigo);

            // Saber se todos os inimigos foram criados e se a lista está vazia (inimgos destruidos)
            if (criacaoInimigosConcluida && inimigos.Count == 0)
            {
                controladorFase.ConcluirFase();
            }
        }
    }

    public void CriarInimigo()
    {
        ConfiguracaoInimigo configuracaoInimigo = GetConfiguracaoInimigoAleatoria();
        Inimigo inimigoPrefab = configuracaoInimigo.InimigoPrefab; // Variável Inimigo para definir o comportamento do prefab

        // Cria um novo inimigo, passando o Sprite, posição e rotação padrão para 2D
        Vector2 posicaoInimigo = GetPosicaoAleatoriaParaInimigo(); // Atribui a posição Random a posicaoInimigo
        Inimigo novoInimigo = Instantiate(inimigoPrefab, posicaoInimigo, Quaternion.identity);
        novoInimigo.Configurar(this, configuracaoInimigo.PropriedadeInimigo);
        inimigos.Add(novoInimigo); // Adiciona um novo inimigo ao ArrayList
    }

    public Vector2 GetPosicaoAleatoriaParaInimigo()
    {
        // Usando a posição da Main Camera para gerar inimigos no topo da tela
        Vector2 posicaoMaxima = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 posicaoMinima = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // Gera um número aleatório para o spaw do inimigo no eixo Horizontal da camêra, com base na posição Horizontal de posicaoMinima e posicaoMaxima
        float posicaoX = Random.Range(posicaoMinima.x, posicaoMaxima.x);

        Vector2 posicaoInimigo = new Vector2(posicaoX, posicaoMaxima.y); // Defini o spaw do inimigo como um valor aleatório de posicaoX e mantendo o posição Vertical(Y) o objeto

        return posicaoInimigo;
    }

    private ConfiguracaoInimigo GetConfiguracaoInimigoAleatoria()
    {
        // Acessa configuracaoControladorInimigo e atribui ConfiguracaoInimigos a variavel do tipo ConfiguracaoInimigo[]
        ConfiguracaoInimigo[] configuracaoInimigos = configuracaoControladorInimigo.ConfiguracaoInimigos;

        if (configuracaoInimigos == null || configuracaoInimigos.Length == 0)
        {
            // Verifica se há inimigo em alguma posição
            return null;
        }

        int indiceAleatorio = Random.Range(0, configuracaoInimigos.Length); // Escolhe um indice aleatorio para a gerar um inimigo
        return configuracaoInimigos[indiceAleatorio];
    }
}
