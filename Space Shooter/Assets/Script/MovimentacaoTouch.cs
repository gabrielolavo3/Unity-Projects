using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoTouch : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody2DJogador;
    [SerializeField] private float velocidadeMovimentacao;
    private Camera camera;
    
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);

            Vector2 posicaoToque = toque.position; // Obt�m a posi��o atual do mouse
            Vector2 posicaoNoMundo2d = camera.ScreenToWorldPoint(posicaoToque); // Converte uma posi��o na tela em uma posi��o 2d
            Vector2 novaPosicao = Vector2.Lerp(transform.position, posicaoNoMundo2d, (velocidadeMovimentacao * Time.deltaTime)); // Faz a movimenta��o atual do jogador at� a posi��o atual do mouse, em uma velocidade determinada

            rigidBody2DJogador.position = novaPosicao; // Muda a posi��o do jogador para a posi��o atual do mouse
        }
    }
}
