using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArmaBasica : MonoBehaviour
{
    public Laser laserPrefab; // variável para indicar o Sprite do Laser no Inspector
    public float tempoDeEsperaDotiro; // Variável para inserir o valor no Inspector
    private float intervaloTiro;
    public Transform[] posicaoDisparo; // Array para obter o position de cada arma

    public virtual void Start() // O virtual permite a sobreescrita do método Start em classes filhas. O identificador de acesso é essencial
    {
        intervaloTiro = 0;
    }
    
    void Update()
    {
        // Adiciona o tempo passado na Unity
        intervaloTiro += Time.deltaTime;

        // Analisa se o tempo de intervaloTiro é maior do que tempoDeEsperaDotiro(definido no inspecto)
        if (intervaloTiro >= tempoDeEsperaDotiro)
        {
            // Zera o intervaloTiro e chama o método atirar, que irá mudar a posição a arma a cada chamada do Update
            intervaloTiro = 0;
            Atirar();
        }
    }

    protected void CriarLaser(Vector2 posicao) 
    {
        // Cria uma instância do Prefab do laser
        Instantiate(laserPrefab, posicao, Quaternion.identity);
    }

    protected abstract void Atirar(); // O uso do abstract permite a alteração em classes que herdam dessa
}
