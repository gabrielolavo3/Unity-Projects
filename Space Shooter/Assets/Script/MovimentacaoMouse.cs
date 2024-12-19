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
        Vector2 posicaoMouse = Input.mousePosition; // Obtém a entrado do mouse
        Vector2 posicaoNoMundo2d = camera.ScreenToWorldPoint(posicaoMouse);
        Vector2 novaPosicao = Vector2.Lerp(transform.position, posicaoNoMundo2d, (velocidadeMovimentacao * Time.deltaTime));

        rigidBodyJogador.position = novaPosicao;
    }
}
