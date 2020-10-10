using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class jugarCuento : MonoBehaviour
{   

    public Button btnPlay;
    public Text txtNombreCuento;

    public GameObject infoCuento;
    public Text txtInfoCuento;
    public GameObject estrella1;
    public GameObject estrella2;
    public GameObject estrella3;

    public string[] nombreCuento;
    public int numeroPreguntas;

    private int idCuento;

    // Start is called before the first frame update
    void Start()
    {
        idCuento = 0;
        txtNombreCuento.text = nombreCuento[idCuento];
        txtInfoCuento.text = "";
        infoCuento.SetActive(false);
        estrella1.SetActive(false);
        estrella2.SetActive(false);
        estrella3.SetActive(false);
        btnPlay.interactable = false;
    }

    
    public void seleccionarCuento(int i)
    {
        idCuento = i;
        
        PlayerPrefs.SetInt("idCuento", idCuento);

        txtNombreCuento.text = nombreCuento[idCuento];

        int notaFinal = PlayerPrefs.GetInt("notaFinal" + idCuento.ToString());
        int aciertos = PlayerPrefs.GetInt("aciertos" + idCuento.ToString());

        estrella1.SetActive(false);
        estrella2.SetActive(false);
        estrella3.SetActive(false);

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

        txtInfoCuento.text = "Acertaste " + aciertos.ToString() + " de " + numeroPreguntas.ToString() + " preguntas";
        infoCuento.SetActive(true);
        btnPlay.interactable = true;
    }

    public void jugar()
    {
        SceneManager.LoadScene("testCuento"+idCuento.ToString());
    }
}
