using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeInimigos : MonoBehaviour
{
    [SerializeField] private PesoInimigo[] inimigos;
    private int totalPesos;
    
    void Start()
    {
        foreach (PesoInimigo a in inimigos)
        {
            totalPesos += a.peso;
        }
        StartCoroutine(GerarInimigos());
    }
    
    private IEnumerator GerarInimigos() 
    {
        while (true) 
        {
            int quantidadeInimigos = Random.Range(1, 4);

            for (int c = 0; c < quantidadeInimigos; c++) 
            { 
                Instantiate(getInimigo(), new Vector3(Random.Range(3.5f, 7.5f), Random.Range(-4.5f, 4.5f), 0), Quaternion.identity);
            }

            yield return new WaitForSeconds(3f);
        }
    }

    private GameObject getInimigo() 
    {
        int numeroSortiado = Random.Range(0, totalPesos) + 1;
        int pesoProcessado = 0;

        for (int b = 0; b < inimigos.Length; b++) 
        {
            pesoProcessado += inimigos[b].peso;

            if (numeroSortiado <= pesoProcessado) 
            {
                return inimigos[b].inimigo;
            }
        }

        return null;
    }
}
