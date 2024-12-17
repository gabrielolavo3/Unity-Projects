using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanoFundoInfinito : MonoBehaviour
{
    public Renderer renderer;
    public float velocidade;
    private Material material;
    private Vector2 offsetMaterial;

    void Start()
    {
        this.material = renderer.material;
        this.offsetMaterial = material.GetTextureOffset("_MainTex");
    }
  
    void Update()
    {
        this.offsetMaterial.y -= velocidade * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offsetMaterial);
    }
}
