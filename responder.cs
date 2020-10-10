using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class responder : MonoBehaviour
{   

    private int idCuento;

    public Text pregunta;
    public Text respuestaA;
    public Text RespuestaB;
    public Text RespuestaC;
    public Text infoRespuestas;

    public string[] preguntas; // Almacena todas las preguntas
    public string[] opcionA; // Almacena todas las opciones A
    public string[] opcionB; // Almacena todas las opciones B
    public string[] opcionC; // Almacena todas las opciones C
    public string[] opcionCorrecta; // Almacena todas las opciones correctas

    private int idPregunta;

    private float aciertos;
    private float totalPreguntas;
    private float media;
    private int notaFinal;

    // Start is called before the first frame update
    void Start()
    {

        idCuento = PlayerPrefs.GetInt("idCuento");

        idPregunta = 0;
        totalPreguntas = preguntas.Length;

        pregunta.text = preguntas[idPregunta];
        respuestaA.text = opcionA[idPregunta];
        RespuestaB.text = opcionB[idPregunta];
        RespuestaC.text = opcionC[idPregunta];
        
        infoRespuestas.text = "Pregunta " + (idPregunta+1).ToString() + " de " + totalPreguntas.ToString();
    }


    public void respuesta (string opcion)
    {
        if (opcion == "A")
        {
            if(opcionA[idPregunta] == opcionCorrecta[idPregunta])
            {
                aciertos += 1;
            }
        }

        else if (opcion == "B")
        {
            if(opcionB[idPregunta] == opcionCorrecta[idPregunta])
            {
                aciertos += 1;
            }
        }

        else if (opcion == "C")
        {
            if(opcionC[idPregunta] == opcionCorrecta[idPregunta])
            {
                aciertos += 1;
            }
        }

        proximaPregunta();

    }

    void proximaPregunta ()
    {
        idPregunta += 1;
        
        if (idPregunta <= (totalPreguntas - 1))
        {
        pregunta.text = preguntas[idPregunta];
        respuestaA.text = opcionA[idPregunta];
        RespuestaB.text = opcionB[idPregunta];
        RespuestaC.text = opcionC[idPregunta];
        
        infoRespuestas.text = "Pregunta " + (idPregunta+1).ToString() + " de " + totalPreguntas.ToString();
        }

        else 
        {   

            //Calcular Nota Final
            media = 10 * (aciertos / totalPreguntas);

            notaFinal = Mathf.RoundToInt(media);

            if (notaFinal > PlayerPrefs.GetInt("notaFinal" + idCuento.ToString()))
            {
                PlayerPrefs.SetInt("notaFinal" + idCuento.ToString(), notaFinal);
                PlayerPrefs.SetInt("aciertos" + idCuento.ToString(), (int) aciertos);
            }

            PlayerPrefs.SetInt("notaFinalTemp" + idCuento.ToString(), notaFinal);
            PlayerPrefs.SetInt("aciertosTemp" + idCuento.ToString(), (int) aciertos);

            SceneManager.LoadScene("notaFinal");
        }
    }
}
