using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanoLogic : MonoBehaviour
{
    public float velocidadeDoCano;

    void Start()
    {
        
    }
    
    void Update()
    {
        CanoMovimento();
    }

    void CanoMovimento() 
    {
        transform.position += Vector3.left * velocidadeDoCano * Time.deltaTime;
    }
}
