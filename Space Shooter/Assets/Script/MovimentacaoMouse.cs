using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoMouse : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBodyJogador;
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
        Vector2 posicaoMouse = Input.mousePosition; // Obtém a posição atual do mouse
        Vector2 posicaoNoMundo2d = camera.ScreenToWorldPoint(posicaoMouse); // Converte uma posição na tela em uma posição 2d
        Vector2 novaPosicao = Vector2.Lerp(transform.position, posicaoNoMundo2d, (velocidadeMovimentacao * Time.deltaTime)); // Faz a movimentação atual do jogador até a posição atual do mouse, em uma velocidade determinada

        rigidBodyJogador.position = novaPosicao; // Muda a posição do jogador para a posição atual do mouse
    }
}
