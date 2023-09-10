using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using DatosUsuario;
using UnityEngine.Networking;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.Audio;

public class DrinkWaterRave : MonoBehaviour
{
    Collider _collider;
    float SavedTime = 0f;
    float DelayTime = 1f;
    float SavedCheckTime = 0f;
    float CheckTime = 30f;
    int id_usuario = 1;
    int id_sustancia = 1;
    string uri_get;
    string uri_update;
    //Variables que cambian con los get
    float agua_usuario;
    float temperatura_usuario;
    public AudioSource convulsiones;
    public AudioMixerSnapshot overhyd;

    public Animator transition;

    private float ml = 500f; //Cantidad de agua inicial
    bool drogas = false;
    bool baile = false;

    private float ml_por_segundo = 25f; //Ml que debe tomar
    //Revisar cada 1 segundos
    float TempTime = 0f; 
    float DelayTempTime = 1f;

    //Tiempo desde que toma el agua
    float TiempoDroga = 0f; //Tiempo en el que empieza a tomar aguita

    float DelayTiempoDroga = 1f; //Cada 1 segundos va aumentando el agua tomada
    float SavedTiempoDroga = 0f; //A

    float TiempoConvulsion;
    //Objeto de camara Camara Offset
    public GameObject camara_efectos;
    public GameObject boca_vomito;

    //Cuanto ml ha tomado del tap
    float ml_tap = 0f;

    // Start is called before the first frame update
    bool vomito = false;
    
    //Particulas
    public GameObject Particulas;
    public GameObject ElScriptParticulas;
    private bool deteccion = false;

    private bool convulsiones_A = false;
    //public GameObject botella;
    void Start()
    {
        _collider = GetComponent<Collider>();
        //_collider.isTrigger = true;

        uri_get = "https://2073-200-124-49-206.ngrok-free.app/datossesionusuario?id_usuario=" + id_usuario + "&id_sustancia=" + id_sustancia;
        uri_update = "https://2073-200-124-49-206.ngrok-free.app/updatedatos?id_usuario=" + id_usuario + "&id_sustancia=" + id_sustancia;

        //StartCoroutine(GetData_Coroutine());
    
    }

    void OnTriggerEnter(Collider other)
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        //Vaso de agua
        if (other.CompareTag("Botella"))
        {
            //Se corta el tiempo
            SavedTiempoDroga = 0f; //A
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Botella") && Particulas.GetComponent<ParticleSystem>().isPlaying)
        {
            //Debug.Log("tiempo " + Time.time);
            if ((Time.time - SavedTiempoDroga) > DelayTiempoDroga)
            {
                //Debug.Log("Resta " + (Time.time - SavedTiempoDroga));
                SavedTiempoDroga = Time.time;
                
                //Anything in here will be called every one second
                //
                Debug.Log("Toma aguita");

                ml = ml - ml_por_segundo;

                Debug.Log("Cantidad de agua" + ml);
            }
            //Empiezo a correr tiempo
            TiempoDroga = Time.time;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (ml == 0)
        {
            if((Time.time - TiempoDroga) < 30f)
            {
                //Se muere
                Debug.Log("Se muere");

                //Aumento de la distorsion 
                LensDistortion tmp;

                camara_efectos.GetComponent<Volume>().profile.TryGet<LensDistortion>(out tmp);
                //tmp.intensity.value = 1;
                tmp.active = true;

                //Sonidos de convulsiones y camara
                overhyd.TransitionTo(.01f);
                camara_efectos.GetComponent<ShakeableTransform>().enabled = true;
                convulsiones.Play();


                convulsiones_A = true;
                TiempoConvulsion = Time.time;
                
            }

            ElScriptParticulas.GetComponent<ParticulasAguita2>().IsFinished = true;
            //botella.SetActive(false);
        }

        if(convulsiones_A && (Time.time - TiempoConvulsion > 5f))
        {
            transition.SetTrigger("Start");
        }


    }
}
