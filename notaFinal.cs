using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class notaFinal : MonoBehaviour  
{
    [SerializeField]private AudioClip f1 = null;
    [SerializeField]private AudioClip f2 = null;
    [SerializeField]private AudioClip f3 = null;
    [SerializeField]private AudioClip f4 = null;
    [SerializeField]private AudioSource audioSource = null;

    private int idCuento;

    public comandosBasicos gameManager;

    public Text txtNota;
    public Text txtInfoCuento;
    public Text txtRetro;

    public GameObject estrella1;
    public GameObject estrella2;
    public GameObject estrella3;

    private int notaF;
    private int aciertos;

    void Start()
    {   
        audioSource = GetComponent<AudioSource>();

        idCuento = PlayerPrefs.GetInt("idCuento");

        estrella1.SetActive(false);
        estrella2.SetActive(false);
        estrella3.SetActive(false);
        
        notaF = PlayerPrefs.GetInt("notaFinalTemp" + idCuento.ToString());
        aciertos = PlayerPrefs.GetInt("aciertosTemp" + idCuento.ToString());

        txtNota.text = notaF.ToString();
        txtInfoCuento.text = "Acertaste " + aciertos.ToString() + " de 5";

        if (notaF == 10)
        {
            estrella1.SetActive(true);
            estrella2.SetActive(true);
            estrella3.SetActive(true);
            gameManager.nivelGanado(idCuento);
            txtRetro.text = "Muchas Felicidades \n ¡Sigue así!";
            audioSource.clip = f4;
        }

        else if (notaF >= 6)
        {
            estrella1.SetActive(true);
            estrella2.SetActive(true);
            estrella3.SetActive(false);
            gameManager.nivelGanado(idCuento);
            txtRetro.text = "increíble \n ¡Seguro que puedes hacerlo aún mejor!";
            audioSource.clip = f3;
        }

        else if (notaF >= 3)
        {
            estrella1.SetActive(true);
            estrella2.SetActive(false);
            estrella3.SetActive(false);
            txtRetro.text = "Ya casi \n ¡Puedes Lograrlo!";
            audioSource.clip = f2;
        }

        else 
        {
            txtRetro.text = "No te rindas \n ¡Intenta de nuevo!";
            audioSource.clip = f1;
        }

        audioSource.Play();
        
    }

    public void jugarNuevamente()
    {
        SceneManager.LoadScene("testCuento"+idCuento.ToString());
    }
}
