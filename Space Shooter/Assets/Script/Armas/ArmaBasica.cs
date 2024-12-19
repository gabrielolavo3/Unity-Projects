using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArmaBasica : MonoBehaviour
{
    public Laser laserPrefab; // vari�vel para indicar o Sprite do Laser no Inspector
    public float tempoDeEsperaDotiro; // Vari�vel para inserir o valor no Inspector
    private float intervaloTiro;
    public Transform[] posicaoDisparo; // Array para obter o position de cada arma

    public virtual void Start() // O virtual permite a sobreescrita do m�todo Start em classes filhas. O identificador de acesso � essencial
    {
        intervaloTiro = 0;
    }
    
    void Update()
    {
        // Adiciona o tempo passado na Unity
        intervaloTiro += Time.deltaTime;

        // Analisa se o tempo de intervaloTiro � maior do que tempoDeEsperaDotiro(definido no inspecto)
        if (intervaloTiro >= tempoDeEsperaDotiro)
        {
            // Zera o intervaloTiro e chama o m�todo atirar, que ir� mudar a posi��o a arma a cada chamada do Update
            intervaloTiro = 0;
            Atirar();
        }
    }

    protected void CriarLaser(Vector2 posicao) 
    {
        // Cria uma inst�ncia do Prefab do laser
        Instantiate(laserPrefab, posicao, Quaternion.identity);
    }

    protected abstract void Atirar(); // O uso do abstract permite a altera��o em classes que herdam dessa
}
