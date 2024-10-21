using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoHorizontal : MonoBehaviour
{
    [SerializeField][Range(0,2)] private float velocidade;

    void Update()
    {
        if (transform.position.x >= -6)
        {
            transform.position -= new Vector3(Time.deltaTime * velocidade, 0, 0);
        }
        else 
        { 
            Destroy(gameObject);
        }
    }
}
