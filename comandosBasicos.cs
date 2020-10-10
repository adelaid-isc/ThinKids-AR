using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class comandosBasicos : MonoBehaviour
{
    public void cargarEscena (string nombreEscena)
    {  
        SceneManager.LoadScene(nombreEscena);
    }

    public void resetearPuntuacion()
    {
        PlayerPrefs.DeleteAll();
    }
}
