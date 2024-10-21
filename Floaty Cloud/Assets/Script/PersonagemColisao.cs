using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemColisao : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite spritePersonsagemGamerOver;
    [SerializeField] private GameObject transicaoGamerOver;
    [SerializeField] private GameObject painelGamerOver;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Inimigo" || collision.gameObject.tag == "Limite") 
        {
            GamerOver();
        }
    }

    private void GamerOver() 
    {
        Time.timeScale = 0;
        spriteRenderer.sprite = spritePersonsagemGamerOver;
        transicaoGamerOver.transform.position = transform.position;
        transicaoGamerOver.SetActive(true);

        StartCoroutine(ExibirPainelGamerOver());
    }

    private IEnumerator ExibirPainelGamerOver() 
    { 
        yield return new WaitForSecondsRealtime(1f);
        painelGamerOver.SetActive(true);
    }
}