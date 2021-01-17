using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Input : MonoBehaviour
{
    
    TouchScreenKeyboard tecladoDef, tecladoNum;
    public Text inputNombre, inputEdad;

    public string nombre, edad, genero;

    public void TecladoDefault()
    {
        tecladoDef = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    public void TecladoNumerico()
    {
        tecladoNum = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NumberPad);
    }

    public void seleccionF()
    {
        genero = "Femenino";
    }

    public void seleccionM()
    {
        genero = "Masculino";
    }

    public void GuardarDatos()
    {
        PlayerPrefs.DeleteAll();

        nombre = inputNombre.text;
        edad = inputEdad.text;
        
        PlayerPrefs.SetString("Nombre", nombre); 
        PlayerPrefs.SetString("Edad", edad); 
        PlayerPrefs.SetString("Genero", genero); 

        SceneManager.LoadScene("Temas");
    }

    void Update()
    {
        if (TouchScreenKeyboard.visible == false && (tecladoDef != null || tecladoNum != null))
        {
            if (tecladoDef.done)
            {
                tecladoDef = null;
            }

            else if (tecladoNum.done)
            {
                tecladoNum = null;
            }
        }
    }
}
