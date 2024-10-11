using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanoSurgir : MonoBehaviour
{
    public float tempoMaximo;
    private float tempo;
    public float distancia;
    public GameObject cano;
    GameObject canoClone;
    
    void Start()
    {
        CanoSpaw();
    }
    
    void Update()
    {
        if (tempo > tempoMaximo)         
        {
            CanoSpaw();
            tempo = 0;
        }

        tempo += Time.deltaTime;
    }

    void CanoSpaw()    
    {
        canoClone = Instantiate(cano);        
        canoClone.transform.position = transform.position + new Vector3(0, Random.Range(-distancia, distancia), 0);
    }
}
