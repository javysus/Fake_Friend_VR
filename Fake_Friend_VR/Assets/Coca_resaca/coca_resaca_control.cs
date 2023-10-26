using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class coca_resaca_control : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource suspiros;
    public AudioSource bostezos;
    public AudioSource estomacales;
    public AudioSource quejidos;
    public AudioSource risas;
    public AudioSource grunidos;
    public AudioSource llantos;
    public GameObject camara;
    private DepthOfField vision_borrosa;
    private MotionBlur borroso;
    public ParticleSystem gotas;

    void Start()
    {

        camara.GetComponent<Volume>().profile.TryGet<DepthOfField>(out vision_borrosa);
        camara.GetComponent<Volume>().profile.TryGet<MotionBlur>(out borroso);
        
        // falta el flujo de los efecto en caso de agregar dialogos
        Invoke("suspirar", 1.0f);
        Invoke("bostezar", 1.0f);

        Invoke("estomago",5.0f);
        Invoke("parar_suspirar",5.0f);
        Invoke("parar_bostezar", 5.0f);

        Invoke("quejarse", 10.0f);
        Invoke("parar_estomago", 10.0f);

        Invoke("reir",15.0f);

        Invoke("parar_reir",20.0f);
        Invoke("grunir", 20.0f);

        Invoke("parar_grunir", 25.0f);
        Invoke("llorar", 25.0f);




        
    }

    
    void suspirar()
    {
        suspiros.Play();
    }
    void parar_suspirar()
    {
        suspiros.Stop();
    }
    void bostezar()
    {
        bostezos.Play();
        
    }
    void parar_bostezar()
    {
        bostezos.Stop();
    }
    void estomago()
    {
        estomacales.Play();
        
    }
    void parar_estomago()
    {
        estomacales.Stop();
    }
    void quejarse()
    {
        quejidos.Play();
    }
    void parar_quejar()
    {
        quejidos.Stop();
    }
    void reir()
    {
        risas.Play();
    }
    void parar_reir()
    {
        risas.Stop();
    }
    void grunir()
    {
        grunidos.Play();
    }
    void parar_grunir()
    {
        grunidos.Stop();
    }
    void llorar()
    {
        llantos.Play();
        gotas.Play();
        vision_borrosa.active = true;
        borroso.active = true;
    }
    void parar_llorar()
    {
        llantos.Stop();
    }
}
