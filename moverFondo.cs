using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverFondo : MonoBehaviour
{

    private Material materialFondo;
    public float velocidad;
    private float offset;

    void Start()
    {
        materialFondo = GetComponent<Renderer>().material;
    }

    void FixedUpdate()
    {
        offset += 0.001f;
        materialFondo.SetTextureOffset("_MainTex", new Vector2(offset * velocidad, 0));
    }

}
