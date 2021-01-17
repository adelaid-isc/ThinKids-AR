using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Android;
using TextSpeech;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class responder : MonoBehaviour
{   

    [SerializeField]private AudioClip r_correcta = null; 
    [SerializeField]private AudioClip r_incorrecta = null;
    private int ultimoTiempo;
    public GameObject disableButton;
    [SerializeField]private AudioSource audioSource = null;
    public AudioClip[] vozpreguntas;
    public int idAudio = 0;
    public Text txtTiempo; 
    public float tiempo = 40f;
    public float tiempoPartida = 0f;
    public bool tiempoCorriendo = false;
    public bool tiempoRunPartida = false;
    private int cP1, cP2, cP3, cP4, cP5 = 0;
    public int[] rC, rI;
    public Sprite btn_correcto, btn_incorrecto, voz_correcto, voz_incorrecto, defA, defB, defC, defD;
    public Button btnA, btnB, btnC, btnD;
    private int idCuento;
    public Text txtEscucha;
    const string LANG_CODE = "es-MX"; 
    public Text pregunta, respuestaA, RespuestaB, RespuestaC, infoRespuestas;
    public string[] preguntas, opcionA, opcionB, opcionC, opcionCorrecta;
    public string opcionD; 
    private int idPregunta;
    private float aciertos, totalPreguntas, media;
    private int notaFinal;

    void Start()
    {   
        disableButton.SetActive(false);
        idCuento = PlayerPrefs.GetInt("idCuento");
        idPregunta = 0;

        ultimoTiempo = PlayerPrefs.GetInt("mejorTiempo" + idCuento.ToString());

        txtTiempo.text = " " + tiempoPartida;
        tiempoCorriendo = true;
        tiempoRunPartida = true;

        PlayerPrefs.SetString("p1" + idCuento.ToString(), preguntas[0]);
        PlayerPrefs.SetString("p2" + idCuento.ToString(), preguntas[1]);
        PlayerPrefs.SetString("p3" + idCuento.ToString(), preguntas[2]);
        PlayerPrefs.SetString("p4" + idCuento.ToString(), preguntas[3]);
        PlayerPrefs.SetString("p5" + idCuento.ToString(), preguntas[4]);

        cP1 = PlayerPrefs.GetInt("cP1" + idCuento.ToString());
        cP2 = PlayerPrefs.GetInt("cP2" + idCuento.ToString());
        cP3 = PlayerPrefs.GetInt("cP3" + idCuento.ToString());
        cP4 = PlayerPrefs.GetInt("cP4" + idCuento.ToString());
        cP5 = PlayerPrefs.GetInt("cP5" + idCuento.ToString());

        rC[idPregunta] = PlayerPrefs.GetInt("rC" + idPregunta.ToString() + idCuento.ToString());
        rI[idPregunta] = PlayerPrefs.GetInt("rI" + idPregunta.ToString() + idCuento.ToString());

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = vozpreguntas[idAudio];
        audioSource.Play();

        Setup(LANG_CODE);  
        SpeechToText.instance.onPartialResultsCallback = OnPartialSpeechResult;
        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;
        CheckPermission();

        totalPreguntas = preguntas.Length;

        pregunta.text = preguntas[idPregunta];
        respuestaA.text = opcionA[idPregunta];
        RespuestaB.text = opcionB[idPregunta];
        RespuestaC.text = opcionC[idPregunta];
        
        infoRespuestas.text = "Pregunta " + (idPregunta+1).ToString() + " de " + totalPreguntas.ToString();
    }

    void Update () {

        tiempoPartida += Time.deltaTime;
        txtTiempo.text = " " + tiempoPartida.ToString("f0");

        if (tiempoCorriendo)
        {
            if(tiempo > 0)
            {
                tiempo -= Time.deltaTime;
            }

            else 
            {
                tiempo = 40f; 
                audioSource.Play();

                if (idPregunta == 0){ 
                    cP1++;
                    PlayerPrefs.SetInt("cP1" + idCuento.ToString(), cP1);
                }
                else if (idPregunta == 1){ 
                    cP2++;
                    PlayerPrefs.SetInt("cP2" + idCuento.ToString(), cP2);
                }
                else if (idPregunta == 2){ 
                    cP3++;
                    PlayerPrefs.SetInt("cP3" + idCuento.ToString(), cP3);
                }
                else if (idPregunta == 3) 
                {
                    cP4++;
                    PlayerPrefs.SetInt("cP4" + idCuento.ToString(), cP4);
                }
                else if (idPregunta == 4) 
                {
                    cP5++;
                    PlayerPrefs.SetInt("cP5" + idCuento.ToString(), cP5);
                }
            }
        } 
    }

    public void respuesta (string opcion)
    {
        rC[idPregunta] = PlayerPrefs.GetInt("rC" + idPregunta.ToString() + idCuento.ToString());
        rI[idPregunta] = PlayerPrefs.GetInt("rI" + idPregunta.ToString() + idCuento.ToString());

        if (opcion == "A")
        {
            if(opcionA[idPregunta] == opcionCorrecta[idPregunta])
            {
                aciertos += 1;

                rC[idPregunta]++; 
                PlayerPrefs.SetInt("rC" + idPregunta.ToString() + idCuento.ToString(), rC[idPregunta]); 
                
                audioSource.clip = r_correcta; 
                btnA.GetComponent<Image>().sprite = btn_correcto;
            }
            
            else
            {
                rI[idPregunta]++; 
                PlayerPrefs.SetInt("rI" + idPregunta.ToString() + idCuento.ToString(), rI[idPregunta]); 

                audioSource.clip = r_incorrecta; 
                btnA.GetComponent<Image>().sprite = btn_incorrecto; 
            }

            audioSource.Play();  
            btnB.interactable = false;
            btnC.interactable = false; 
            btnD.interactable = false; 
        }

        else if (opcion == "B")
        {
            if(opcionB[idPregunta] == opcionCorrecta[idPregunta])
            {
                aciertos += 1;

                rC[idPregunta]++;
                PlayerPrefs.SetInt("rC" + idPregunta.ToString() + idCuento.ToString(), rC[idPregunta]);
                
                audioSource.clip = r_correcta;
                btnB.GetComponent<Image>().sprite = btn_correcto;
            }
            else
            {
                rI[idPregunta]++;
                PlayerPrefs.SetInt("rI" + idPregunta.ToString() + idCuento.ToString(), rI[idPregunta]);

                audioSource.clip = r_incorrecta;
                btnB.GetComponent<Image>().sprite = btn_incorrecto;
            }

            audioSource.Play();
            btnA.interactable = false;
            btnC.interactable = false;
            btnD.interactable = false;
        }

        else if (opcion == "C")
        {
            if(opcionC[idPregunta] == opcionCorrecta[idPregunta])
            {
                aciertos += 1;

                rC[idPregunta]++;
                PlayerPrefs.SetInt("rC" + idPregunta.ToString() + idCuento.ToString(), rC[idPregunta]);

                audioSource.clip = r_correcta;
                btnC.GetComponent<Image>().sprite = btn_correcto;
            }
            else
            {
                rI[idPregunta]++;
                PlayerPrefs.SetInt("rI" + idPregunta.ToString() + idCuento.ToString(), rI[idPregunta]);

                audioSource.clip = r_incorrecta;
                btnC.GetComponent<Image>().sprite = btn_incorrecto;
            }

            audioSource.Play();
            btnA.interactable = false;
            btnB.interactable = false;
            btnD.interactable = false;
        }

        disableButton.SetActive(true);
        Invoke("proximaPregunta", 1.3f);
    }

    void proximaPregunta ()
    {   
        idPregunta += 1; 
        idAudio += 1;

        tiempo = 40f;
        disableButton.SetActive(false);

        if (idPregunta <= (totalPreguntas - 1))
        {

            audioSource.clip = vozpreguntas[idAudio];
            audioSource.Play();

            btnA.interactable = true;
            btnB.interactable = true;
            btnC.interactable = true;
            btnD.interactable = true;

            btnA.GetComponent<Image>().sprite = defA;
            btnB.GetComponent<Image>().sprite = defB;
            btnC.GetComponent<Image>().sprite = defC;
            btnD.GetComponent<Image>().sprite = defD;

            pregunta.text = preguntas[idPregunta];
            respuestaA.text = opcionA[idPregunta];
            RespuestaB.text = opcionB[idPregunta];
            RespuestaC.text = opcionC[idPregunta];
            
            infoRespuestas.text = "Pregunta " + (idPregunta+1).ToString() + " de " + totalPreguntas.ToString();
        
        }

        else 
        {   
            tiempoCorriendo = false;
            tiempoRunPartida = false;

            if ((int)tiempoPartida < ultimoTiempo || ultimoTiempo == 0) 
            {   
                PlayerPrefs.SetInt("mejorTiempo" + idCuento.ToString(), (int)tiempoPartida); 
            }

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

    void Setup (string code)
    {
        SpeechToText.instance.Setting(code);
    }

    #region Speech to Text

    public void StartListening()
    {
        SpeechToText.instance.StartRecording();
    }

    public void StopListening()
    {
        SpeechToText.instance.StopRecording();
    }

    void OnFinalSpeechResult(string result)
    {
        opcionD = result; 
        txtEscucha.text = opcionD;

        if(opcionD == opcionCorrecta[idPregunta])
        {
            aciertos += 1;

            rC[idPregunta]++;
            PlayerPrefs.SetInt("rC" + idPregunta.ToString() + idCuento.ToString(), rC[idPregunta]);

            audioSource.clip = r_correcta;
            btnD.GetComponent<Image>().sprite = voz_correcto;
        } 
        
        else
        {
            rI[idPregunta]++;
            PlayerPrefs.SetInt("rI" + idPregunta.ToString() + idCuento.ToString(), rI[idPregunta]);
            
            audioSource.clip = r_incorrecta;
            btnD.GetComponent<Image>().sprite = voz_incorrecto;
        }

        audioSource.Play();
        btnA.interactable = false;
        btnB.interactable = false;
        btnC.interactable = false;

        Invoke("proximaPregunta", 1.3f);
    }

    void OnPartialSpeechResult(string result)
    {   
        opcionD = result;
        txtEscucha.text = opcionD;
    }

    void CheckPermission()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
    }

    #endregion

}
