using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova propriedade", menuName = "Space Shooter/Inimigo/Propriedade Inimigo")]
public class PropriedadeInimigo : ScriptableObject
{
    [SerializeField] private float velocidadeMinima;
    [SerializeField] private float velocidadeMaxima;
    [SerializeField] private int quantidadeMaximaVida;
    [SerializeField] [Range(0, 100)] private float chanceSoltarItemVida; // O [Range(0, 100)] permite escolher um valor dentro do intervalo minímo (0) e máximo (100) no inspetor
    [SerializeField] private ItemVida itemVidaPrefab; // Variável privada para aparece no inspecto por causa do SerializeField
    [SerializeField] [Range(0, 100)] private float chanceSoltarPowerUp;
    [SerializeField] private PowerUpColetavel[] powerUpPrefabs; // Recebe uma coleção de prefabs

    public float VelocidadeMinima
    {
        get
        {
            return velocidadeMinima;
        }
    }

    public float VelocidadeMaxima
    {
        get
        {
            return velocidadeMaxima;
        }
    }

    public float QuantidadeMaximaVida
    {
        get
        {
            return quantidadeMaximaVida;
        }
    }

    public float ChanceSoltarItemVida
    {
        get
        {
            return chanceSoltarItemVida;
        }
    }

    public ItemVida ItemVidaPrefab
    {
        get
        {
            return itemVidaPrefab;
        }
    }

    public float ChanceSoltarPowerUp
    {
        get
        {
            return chanceSoltarPowerUp;
        }
    }

    public PowerUpColetavel[] PowerUpPrefabs
    {
        get
        {
            return powerUpPrefabs;
        }
    }
}
