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
        // Cria uma vari�vel do tipo Camera, que � atribuida a posi��o do GameObject com rela��o a Camera da Unity ao Vector3
        Camera camera = Camera.main;
        Vector3 posicaoLaserNaCamera = camera.ViewportToWorldPoint(this.transform.position);
        
        if (posicaoLaserNaCamera.y > 1) 
        {
            // Verifica se a posi��o Y do Laser na cam�ra � maior do que 1 e destr�i o GameObject
            Destroy(this.gameObject, 0.5f);
        }
    }

    // M�todo para Colisor IsTrigger - Colidi, mas n�o h� a��o da fisica
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colis�o com " + collision.name);

        // Compara se a colis�o ocorreu com GameObject com a Tag "Inimigo"
        if (collision.CompareTag("Inimigo"))
        {
            Inimigo inimigo = collision.GetComponent<Inimigo>(); // Acessa o script Inimigo e atribuir a variavel o Componente
            inimigo.ReceberDano(); // Usa a vari�vel para acessar o metodo do sript e retirar ponto de vida do GameObject Inimigo
            Destroy(this.gameObject); // Destroi o GameObject do laser
        }
    }
}
