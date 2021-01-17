using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuentoInfo : MonoBehaviour
{

    public int idCuento;

    public GameObject estrella1;
    public GameObject estrella2;
    public GameObject estrella3;

    private int notaFinal;

    void Start()
    {

        estrella1.SetActive(false);
        estrella2.SetActive(false);
        estrella3.SetActive(false);

        notaFinal = PlayerPrefs.GetInt("notaFinal" + idCuento.ToString());

        if (notaFinal == 10)
        {
            estrella1.SetActive(true);
            estrella2.SetActive(true);
            estrella3.SetActive(true);
        }

        else if (notaFinal >= 6)
        {
            estrella1.SetActive(true);
            estrella2.SetActive(true);
            estrella3.SetActive(false);
        }

        else if (notaFinal >= 3)
        {
            estrella1.SetActive(true);
            estrella2.SetActive(false);
            estrella3.SetActive(false);
        }
        
    }
    
}
