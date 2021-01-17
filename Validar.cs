using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Validar : MonoBehaviour
{
    public Button Continuar;
    public Sprite deshabilitado, habilitado;

    void Start()
    {
        if(!PlayerPrefs.HasKey("Nombre"))
        {
            Continuar.GetComponent<Image>().sprite = deshabilitado;
            Continuar.interactable = false;
        }

        else 
        {
            Continuar.interactable = true;
            Continuar.GetComponent<Image>().sprite = habilitado;
        }
    }

    public void VerificarPartida()
    {
        SceneManager.LoadScene("Temas");
    }

}
