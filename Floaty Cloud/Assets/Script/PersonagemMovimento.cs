using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemMovimento : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite spritePersonagemParado;
    [SerializeField] private Sprite spritePersonagemMovimento;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * 150);
            spriteRenderer.sprite = spritePersonagemMovimento;

            StopAllCoroutines();
            StartCoroutine(MudarParaSpriteParado());
        }
    }

    private IEnumerator MudarParaSpriteParado()
    { 
        yield return new WaitForSeconds(1.0f);
        spriteRenderer.sprite = spritePersonagemParado;
    }
}
