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

    // Método para Colisor IsTrigger - Colidi, mas não há ação da fisica
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colisão com " + collision.name);

        // Compara se a colisão ocorreu com GameObject com a Tag "Inimigo"
        if (collision.CompareTag("Inimigo"))
        {
            Inimigo inimigo = collision.GetComponent<Inimigo>(); // Acessa o script Inimigo e atribuir a variavel o Componente
            inimigo.Destuir(true); // Usa a variaável para acessar o metodo do sript e destruir o GameObject 
            Destroy(this.gameObject); // Destroi o GameObject do laser
        }
    }
}
