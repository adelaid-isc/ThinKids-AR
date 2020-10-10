using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class notaFinal : MonoBehaviour  
{

    private int idCuento;

    public Text txtNota;
    public Text txtInfoCuento;

    public GameObject estrella1;
    public GameObject estrella2;
    public GameObject estrella3;

    private int notaF;
    private int aciertos;

    // Start is called before the first frame update
    void Start()
    {   

        idCuento = PlayerPrefs.GetInt("idCuento");

        estrella1.SetActive(false);
        estrella2.SetActive(false);
        estrella3.SetActive(false);
        
        notaF = PlayerPrefs.GetInt("notaFinalTemp" + idCuento.ToString());
        aciertos = PlayerPrefs.GetInt("aciertosTemp" + idCuento.ToString());

        txtNota.text = notaF.ToString();
        txtInfoCuento.text = "Acertaste " + aciertos.ToString() + " de 2";

        if (notaF == 10)
        {
            estrella1.SetActive(true);
            estrella2.SetActive(true);
            estrella3.SetActive(true);
        }

        else if (notaF >= 6)
        {
            estrella1.SetActive(true);
            estrella2.SetActive(true);
            estrella3.SetActive(false);
        }

        else if (notaF >= 3)
        {
            estrella1.SetActive(true);
            estrella2.SetActive(false);
            estrella3.SetActive(false);
        }
        
    }

    public void jugarNuevamente()
    {
        SceneManager.LoadScene("testCuento"+idCuento.ToString());
    }

}
