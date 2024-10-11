using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Variável para definir a força de salto do personagem
    // O valor é aplicado diretamente na interface da Unity, pois é pública

    public float ForcaDoBird;

    // Variável que representa a fisica 2D na Unity
    // Controla como o objeto interage com a física: gravidade, força, colisão, etc

    private Rigidbody2D rb2d;

    // Variável para o Script GameOver. Chamado quando o pássaro colidir com um obstáculo
    public GameOver game;
    
    // Método Start -> Inicializado apenas 1 vez, quando o jogo começa
    void Start()
    {
        // Registrando o Componente de fisica 2D ao personagem, dentro da variável
        rb2d = GetComponent<Rigidbody2D>();
    }
    
    // Método Update -> Chamado a cada frame do jogo. Executa a lógica repeditamente durante o uso do jogo
    void Update()
    {
        bird();
    }

    void bird() 
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            rb2d.velocity = Vector2.up * ForcaDoBird;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        game.GameOverAtivar();
    }
}
