using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Material material;
    private Vector2 offset;
    [SerializeField][Range(0,1)] private float velocidade;

    private void Awake()
    {
        material = GetComponent<MeshRenderer>().material;
    }
    
    void Update()
    {
        offset.Set(offset.x + Time.deltaTime * velocidade, 0);
        material.mainTextureOffset = offset;

        if(offset.x >= 1) 
        {
            offset.Set(0, 0);
            material.mainTextureOffset = offset;
        }
    }
}
