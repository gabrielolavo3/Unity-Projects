using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public float velociaddeY;
    
    void Start()
    {
        rigidbody.velocity = new Vector2(0, velociaddeY);
    }

    void Update()
    {
        // Cria uma variável do tipo Camera, que é atribuida a posição do GameObject com relação a Camera da Unity ao Vector3
        Camera camera = Camera.main;
        Vector3 posicaoLaserNaCamera = camera.ViewportToWorldPoint(this.transform.position);
        
        if (posicaoLaserNaCamera.y > 1) 
        {
            // Verifica se a posição Y do Laser na camêra é maior do que 1 e destrói o GameObject
            Destroy(this.gameObject, 0.5f);
        }
    }

    // Método para Colisor IsTrigger - Colidi, mas não há ação da fisica
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colisão com " + collision.name);

        // Compara se a colisão ocorreu com GameObject com a Tag "Inimigo"
        if (collision.CompareTag("Inimigo"))
        {
            Inimigo inimigo = collision.GetComponent<Inimigo>(); // Acessa o script Inimigo e atribuir a variavel o Componente
            inimigo.ReceberDano(); // Usa a variável para acessar o metodo do sript e retirar ponto de vida do GameObject Inimigo
            Destroy(this.gameObject); // Destroi o GameObject do laser
        }
    }
}
