using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Vari�vel para definir a for�a de salto do personagem
    // O valor � aplicado diretamente na interface da Unity, pois � p�blica

    public float ForcaDoBird;

    // Vari�vel que representa a fisica 2D na Unity
    // Controla como o objeto interage com a f�sica: gravidade, for�a, colis�o, etc

    private Rigidbody2D rb2d;

    // Vari�vel para o Script GameOver. Chamado quando o p�ssaro colidir com um obst�culo
    public GameOver game;
    
    // M�todo Start -> Inicializado apenas 1 vez, quando o jogo come�a
    void Start()
    {
        // Registrando o Componente de fisica 2D ao personagem, dentro da vari�vel
        rb2d = GetComponent<Rigidbody2D>();
    }
    
    // M�todo Update -> Chamado a cada frame do jogo. Executa a l�gica repeditamente durante o uso do jogo
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
