using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAudio : MonoBehaviour
{
    // Vari�veis de refer�ncia para AudioClip
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

    private void TocarSom(AudioClip audioClip, float volume = 1) // Vari�vel de refer�ncia
    { 
        audioSource.PlayOneShot(audioClip, volume); // Permite a execu��o de v�rios sons, ao mesmo tempo, sem parar a execu��o do �ltimo
    }

    /*
    private void TocarSomManeiraAlternativa(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        Essa forma faz com que apenas um a�dio seja executado por vez. Outro som ser� executado somente ap�s o t�rmino do �ltimo
    }
    */
}
