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

    // M�todo para Colisor IsTrigger - Colidi, mas n�o h� a��o da fisica
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colis�o com " + collision.name);

        // Compara se a colis�o ocorreu com GameObject com a Tag "Inimigo"
        if (collision.CompareTag("Inimigo"))
        {
            Inimigo inimigo = collision.GetComponent<Inimigo>(); // Acessa o script Inimigo e atribuir a variavel o Componente
            inimigo.Destuir(true); // Usa a varia�vel para acessar o metodo do sript e destruir o GameObject 
            Destroy(this.gameObject); // Destroi o GameObject do laser
        }
    }
}
