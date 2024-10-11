using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacarEditado : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Placar.valorDoPlacar++;
    }
}
