using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placar : MonoBehaviour
{
    public Text textoDoPonto;
    public static float valorDoPlacar;

    void Start()
    {
        valorDoPlacar = 0;
        textoDoPonto.text = valorDoPlacar.ToString();
    }
    
    void Update()
    {
        textoDoPonto.text = valorDoPlacar.ToString();
    }
}
