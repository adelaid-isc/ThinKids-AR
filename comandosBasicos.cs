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

    public void nivelGanado(int levelToUnlock)
    {
        if (PlayerPrefs.GetInt("levelReached") < levelToUnlock)
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);   
        }
    }
}
