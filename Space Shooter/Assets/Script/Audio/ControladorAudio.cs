using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAudio : MonoBehaviour
{
    // Variáveis de referência para AudioClip
    [SerializeField] private AudioClip danoEscudo;
    [SerializeField] private AudioClip danoJogador;
    [SerializeField] private AudioClip derrotaJogador;
    [SerializeField] private AudioClip explosaoInimigo;
    [SerializeField] private AudioClip laser;
    [SerializeField] private AudioClip powerUpColetavel;
    [SerializeField] private AudioClip vidaColetada;
    [SerializeField] private AudioSource audioSource;

    public void TocarSomDanoEscudo()
    {
        TocarSom(danoEscudo);
    }

    public void TocarSomDanoJogador()
    {
        TocarSom(danoJogador);
    }

    public void TocarSomDerrotaJogador()
    {
        TocarSom(derrotaJogador);
    }
    public void TocarSomExplosaoInimigo()
    {
        TocarSom(explosaoInimigo);
    }

    public void TocarSomLaser()
    {
        TocarSom(laser, 0.15f);
    }
    public void TocarSomPowerUpColetavel()
    {
        TocarSom(powerUpColetavel);
    }

    public void TocarSomVidaColetada()
    {
        TocarSom(vidaColetada);
    }

    private void TocarSom(AudioClip audioClip, float volume = 1) // Variável de referência
    { 
        audioSource.PlayOneShot(audioClip, volume); // Permite a execução de vários sons, ao mesmo tempo, sem parar a execução do último
    }

    /*
    private void TocarSomManeiraAlternativa(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        Essa forma faz com que apenas um aúdio seja executado por vez. Outro som será executado somente após o término do último
    }
    */
}
