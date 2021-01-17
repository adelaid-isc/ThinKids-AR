using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reporte : MonoBehaviour
{

    public Text mt1, mt2, mt3;
    public Text nombre,genero,edad;
    public Text peorTiempo;
    
    public Text p1,p2,p3,p4,p5,p6,p7,p8,p9,p10,p11,p12,p13,p14,p15;
    public Text i1,i2,i3,i4,i5,i6,i7,i8,i9,i10,i11,i12,i13,i14,i15;
    public Text a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11,a12,a13,a14,a15;
    public Text e1,e2,e3,e4,e5,e6,e7,e8,e9,e10,e11,e12,e13,e14,e15;

    void Start()
    {
        nombre.text = "Partida de " + PlayerPrefs.GetString("Nombre");
        genero.text = "Género: " + PlayerPrefs.GetString("Genero");
        edad.text = "Edad: " + PlayerPrefs.GetString("Edad");

        mt1.text = "Mejor Tiempo: " + PlayerPrefs.GetInt("mejorTiempo1").ToString() + " seg.";

        p1.text = PlayerPrefs.GetString("p11");
        i1.text = "★ Veces que se Pregunto: " + PlayerPrefs.GetInt("cP11").ToString();
        a1.text = "★ Veces que Acerto: " + PlayerPrefs.GetInt("rC01").ToString();
        e1.text = "★ Veces que No Acerto: " + PlayerPrefs.GetInt("rI01").ToString();

        p2.text = PlayerPrefs.GetString("p21");
        i2.text = "★ Veces que se Pregunto: " + PlayerPrefs.GetInt("cP21").ToString();
        a2.text = "★ Veces que Acerto: " + PlayerPrefs.GetInt("rC11").ToString();
        e2.text = "★ Veces que No Acerto: " + PlayerPrefs.GetInt("rI11").ToString();

        p3.text = PlayerPrefs.GetString("p31");
        i3.text = "★ Veces que se Pregunto: " + PlayerPrefs.GetInt("cP31").ToString();
        a3.text = "★ Veces que Acerto: " + PlayerPrefs.GetInt("rC21").ToString();
        e3.text = "★ Veces que No Acerto: " + PlayerPrefs.GetInt("rI21").ToString();

        p4.text = PlayerPrefs.GetString("p41");
        i4.text = "★ Veces que se Pregunto: " + PlayerPrefs.GetInt("cP41").ToString();
        a4.text = "★ Veces que Acerto: " + PlayerPrefs.GetInt("rC31").ToString();
        e4.text = "★ Veces que No Acerto: " + PlayerPrefs.GetInt("rI31").ToString();

        p5.text = PlayerPrefs.GetString("p51");
        i5.text = "★ Veces que se Pregunto: " + PlayerPrefs.GetInt("cP51").ToString();
        a5.text = "★ Veces que Acerto: " + PlayerPrefs.GetInt("rC41").ToString();
        e5.text = "★ Veces que No Acerto: " + PlayerPrefs.GetInt("rI41").ToString();

        ////////////////////////////////////////////

        mt2.text = "Mejor Tiempo: " + PlayerPrefs.GetInt("mejorTiempo2").ToString() + " seg.";

        p6.text = PlayerPrefs.GetString("p12");
        i6.text = "★ Veces que se Pregunto: " + PlayerPrefs.GetInt("cP12").ToString();
        a6.text = "★ Veces que Acerto: " + PlayerPrefs.GetInt("rC02").ToString();
        e6.text = "★ Veces que No Acerto: " + PlayerPrefs.GetInt("rI02").ToString();

        p7.text = PlayerPrefs.GetString("p22");
        i7.text = "★ Veces que se Pregunto: " + PlayerPrefs.GetInt("cP22").ToString();
        a7.text = "★ Veces que Acerto: " + PlayerPrefs.GetInt("rC12").ToString();
        e7.text = "★ Veces que No Acerto: " + PlayerPrefs.GetInt("rI12").ToString();

        p8.text = PlayerPrefs.GetString("p32");
        i8.text = "★ Veces que se Pregunto: " + PlayerPrefs.GetInt("cP32").ToString();
        a8.text = "★ Veces que Acerto: " + PlayerPrefs.GetInt("rC22").ToString();
        e8.text = "★ Veces que No Acerto: " + PlayerPrefs.GetInt("rI22").ToString();

        p9.text = PlayerPrefs.GetString("p42");
        i9.text = "★ Veces que se Pregunto: " + PlayerPrefs.GetInt("cP42").ToString();
        a9.text = "★ Veces que Acerto: " + PlayerPrefs.GetInt("rC32").ToString();
        e9.text = "★ Veces que No Acerto: " + PlayerPrefs.GetInt("rI32").ToString();

        p10.text = PlayerPrefs.GetString("p52");
        i10.text = "★ Veces que se Pregunto: " + PlayerPrefs.GetInt("cP52").ToString();
        a10.text = "★ Veces que Acerto: " + PlayerPrefs.GetInt("rC42").ToString();
        e10.text = "★ Veces que No Acerto: " + PlayerPrefs.GetInt("rI42").ToString();

        ////////////////////////////////////////////

        mt3.text = "Mejor Tiempo: " + PlayerPrefs.GetInt("mejorTiempo3").ToString() + " seg.";

        p11.text = PlayerPrefs.GetString("p13");
        i11.text = "★ Veces que se Pregunto: " + PlayerPrefs.GetInt("cP13").ToString();
        a11.text = "★ Veces que Acerto: " + PlayerPrefs.GetInt("rC03").ToString();
        e11.text = "★ Veces que No Acerto: " + PlayerPrefs.GetInt("rI03").ToString();

        p12.text = PlayerPrefs.GetString("p23");
        i12.text = "★ Veces que se Pregunto: " + PlayerPrefs.GetInt("cP23").ToString();
        a12.text = "★ Veces que Acerto: " + PlayerPrefs.GetInt("rC13").ToString();
        e12.text = "★ Veces que No Acerto: " + PlayerPrefs.GetInt("rI13").ToString();

        p13.text = PlayerPrefs.GetString("p33");
        i13.text = "★ Veces que se Pregunto: " + PlayerPrefs.GetInt("cP33").ToString();
        a13.text = "★ Veces que Acerto: " + PlayerPrefs.GetInt("rC23").ToString();
        e13.text = "★ Veces que No Acerto: " + PlayerPrefs.GetInt("rI23").ToString();

        p14.text = PlayerPrefs.GetString("p43");
        i14.text = "★ Veces que se Pregunto: " + PlayerPrefs.GetInt("cP43").ToString();
        a14.text = "★ Veces que Acerto: " + PlayerPrefs.GetInt("rC33").ToString();
        e14.text = "★ Veces que No Acerto: " + PlayerPrefs.GetInt("rI33").ToString();

        p15.text = PlayerPrefs.GetString("p53");
        i15.text = "★ Veces que se Pregunto: " + PlayerPrefs.GetInt("cP53").ToString();
        a15.text = "★ Veces que Acerto: " + PlayerPrefs.GetInt("rC43").ToString();
        e15.text = "★ Veces que No Acerto: " + PlayerPrefs.GetInt("rI43").ToString();

    }

}
