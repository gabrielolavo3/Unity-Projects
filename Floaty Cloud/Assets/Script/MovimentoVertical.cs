using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoVertical : MonoBehaviour
{
    [SerializeField][Range(0,2)] private float velocidade;
    
    private enum Direcao 
    { 
        subir,
        descer
    }
    
    private Direcao direcaoAtual;

    void Start()
    {
        int direcaoInicial = Random.Range(0, 2);

        if (direcaoAtual == 0) 
        { 
            direcaoAtual = Direcao.subir;
        } 
        else 
        { 
            direcaoAtual = Direcao.descer;
        }
    }

    
    void Update()
    {
        switch (direcaoAtual) 
        {
            case Direcao.subir:
                transform.position += new Vector3(0 , velocidade * Time.deltaTime, 0);

                if (transform.position.y >= 6) 
                {
                    direcaoAtual = Direcao.descer;
                }
                break;

            case Direcao.descer:
                transform.position -= new Vector3(0, velocidade * Time.deltaTime, 0);

                if (transform.position.y <= -6)
                {
                    direcaoAtual = Direcao.subir;
                }
                break;
        }
    }
}
