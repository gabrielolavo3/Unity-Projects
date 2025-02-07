using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoMouse : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBodyJogador;
    [SerializeField] private float velocidadeMovimentacao;
    private Camera camera;
        
    void Start()
    {
        camera = Camera.main;
    }
    
    /*
    void Update()
    {
        Vector2 posicaoMouse = Input.mousePosition; // Obt�m a posi��o atual do mouse
        Vector2 posicaoNoMundo2d = camera.ScreenToWorldPoint(posicaoMouse); // Converte uma posi��o na tela em uma posi��o 2d
        Vector2 novaPosicao = Vector2.Lerp(transform.position, posicaoNoMundo2d, (velocidadeMovimentacao * Time.deltaTime)); // Faz a movimenta��o atual do jogador at� a posi��o atual do mouse, em uma velocidade determinada

        rigidBodyJogador.position = novaPosicao; // Muda a posi��o do jogador para a posi��o atual do mouse
    }
    */
}
