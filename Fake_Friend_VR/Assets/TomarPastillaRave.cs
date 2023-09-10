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

public class TomarPastillaRave : MonoBehaviour
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
    public AudioSource pitidos;
    public AudioSource latidos;
    public GameObject Luis;
    public GameObject pill;
    //Variables que cambian con los get
    float agua_usuario;
    float temperatura_usuario;

    bool drogas = false;
    bool baile = false;

    //Revisar cada 3 segundos
    float TempTime = 0f;
    float DelayTempTime = 5f;

    //Tiempo desde que tomo la droga
    float TiempoDroga = 0f;
    float DelayTiempoDroga = 30f; //Cada 30 segundos va aumentando la temperatura 
    float SavedTiempoDroga = 0f;
    float aumentoT_1 = 0.2f;

    //Tiempo desde que baila
    float DelayTiempoBaile = 3f; //Cada 3 segundos va aumentando la temperatura
    float SavedTiempoBaile = 30f;

    float aumentoT_2 = 0.05f;

    //Objeto de camara Camara Offset
    public GameObject camara_efectos;
    public GameObject boca_vomito;

    //Musica para distorsion
    public AudioMixerSnapshot normal;
    public AudioMixerSnapshot drugged;
    public AudioMixerSnapshot overhyd;

    //Cuanto ml ha tomado del tap
    float ml_tap = 0f;

    // Start is called before the first frame update
    bool vomito = false;
    void Start()
    {
        _collider = GetComponent<Collider>();
        //_collider.isTrigger = true;

        /*
        uri_get = "https://2073-200-124-49-206.ngrok-free.app/datossesionusuario?id_usuario=" + id_usuario + "&id_sustancia=" + id_sustancia;
        uri_update = "https://2073-200-124-49-206.ngrok-free.app/updatedatos?id_usuario=" + id_usuario + "&id_sustancia=" + id_sustancia;

        StartCoroutine(GetData_Coroutine());
        */
    }

    /*IEnumerator GetData_Coroutine()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(uri_get))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log("Test Error al consultar a la base de datos");
            }
            else
            {
                Debug.Log("Test " + request.downloadHandler.text);
                var desData = JsonConvert.DeserializeObject<Root>(request.downloadHandler.text);

                Debug.Log("Test " + desData.mensaje);

                var sesion = desData.sesion;

                Debug.Log("Test" + sesion);

                var agua = sesion.agua_organismo;

                Debug.Log("Test" + agua);

                temperatura_usuario = float.Parse(sesion.temperatura_corp, CultureInfo.InvariantCulture.NumberFormat);
                Debug.Log("Temperatura " + temperatura_usuario);
            }
        }
    }

    IEnumerator PostData_Coroutine()
    {
        WWWForm form = new WWWForm();
        form.AddField("temperatura_corp", temperatura_usuario.ToString());

        Dictionary<string, string> headers = form.headers;
        byte[] rawData = form.data;

        //byte[] myData = System.Text.Encoding.UTF8.GetBytes(form);

        byte[] myData = System.Text.Encoding.UTF8.GetBytes("{\"temperatura_corp\": \"" + temperatura_usuario.ToString() + "\"}");
        Debug.Log("Temperatura a string " + temperatura_usuario.ToString());
        Debug.Log("Temperatura enviada " + myData);
        using (UnityWebRequest request = UnityWebRequest.Put(uri_update, myData))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log("Error al consultar a la base de datos");
            }
            else
            {
                Debug.Log("Test enviado" + request.downloadHandler.text);
            }
        }
    }
    */
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Test colision entrar " + other);
        GameObject game = other.gameObject;
        if (other.tag == "Pastilla")
        {
            Debug.Log("Test pastilla colisiona");
            TiempoDroga = Time.time;
            drogas = true;
            //Desactivar componente de pastilla
            pill.SetActive(false);

        }

        //Vaso de agua
        Spill consumable = game.GetComponent<Spill>();
        Debug.Log("Test colision" + consumable);
        if (consumable != null && !consumable.IsFinished)
        {
            Debug.Log("Test colisiona con vaso ");
            consumable.Consume();
        }

        //Agua de grifo
        TapWater grifo = game.GetComponent<TapWater>();

        if (grifo != null)
        {
            Debug.Log("Test colisiona con grifo ");
            if ((Time.time - SavedTime) > DelayTime)
            {
                SavedTime = Time.time;

                //Anything in here will be called every one second
                //
                Debug.Log("Test tomando agua 1 segundo");
                grifo.DrinkFromTap();
            }

        }
    }
    /*void OnTriggerStay(Collider other)
    {
        //Vaso de agua
        Spill consumable = other.GetComponent<Spill>();
        Debug.Log("Test colision" + consumable);
        if (consumable != null && !consumable.IsFinished)
        {
            Debug.Log("Test colisiona con vaso ");
            consumable.Consume();
        }

        //Agua de grifo
        TapWater grifo = other.GetComponent<TapWater>();

        if (grifo != null)
        {
            Debug.Log("Test colisiona con grifo ");
            if ((Time.time - SavedTime) > DelayTime)
            {
                SavedTime = Time.time;

                //Anything in here will be called every one second
                //
                Debug.Log("Test tomando agua 1 segundo");
                grifo.DrinkFromTap();
            }
            
        }
    }*/

    void OnTriggerExit(Collider other)
    {
        //Vaso de agua
        GameObject game = other.gameObject;
        Spill consumable = game.GetComponent<Spill>();

        /*
        if (consumable != null && !consumable.IsFinished)
        {
            Debug.Log("Test colision exit");

            consumable.ActualizarPersonaje();
            temperatura_usuario = 37.0f; //Vuelve a la normalidad
            StartCoroutine(PostData_Coroutine());
        }

        //Agua de grifo
        TapWater grifo = other.GetComponent<TapWater>();

        if (grifo != null)
        {
            ml_tap = ml_tap + grifo.ActualizarPersonaje();

            if (ml_tap > 255.0f)
            {
                temperatura_usuario = 37.0f;

                StartCoroutine(PostData_Coroutine());
            }
        }
        */
    }
    // Update is called once per frame
    void Update()
    {
        //Actualizar la temperatura del usuario cada 30 segundos
        /*if ((Time.time - SavedCheckTime) > CheckTime)
        {
            SavedCheckTime = Time.time;

            Debug.Log("Temperatura: " + temperatura_usuario);

            StartCoroutine(PostData_Coroutine());

        }*/
        //Debug.Log("Test de tiempo: " + (Time.time - TiempoDroga));
        //Debug.Log("Test de drogas: " + drogas);

        if ((Time.time - TiempoDroga) > 15.0f && (Time.time - TiempoDroga) < 20 && drogas)
        {
            //Se escuchan latidos de corazon
            Luis.GetComponent<LogicaLuisNPC>().dialogo1 = true;
        }
        
        if ((Time.time - TiempoDroga) > 15.0f && (Time.time - TiempoDroga) < 20 && drogas)
        {
            //Se escuchan latidos de corazon
            latidos.Play();
            Debug.Log("Latidos!!!");
            drugged.TransitionTo(.01f);
        }
        
        if ((Time.time - TiempoDroga) > 20.0f && drogas && (Time.time - TiempoDroga) < 25.0f)
        {
            Debug.Log("Drogas Test");
            Bloom tmp;
            camara_efectos.GetComponent<Volume>().profile.TryGet<Bloom>(out tmp);
            tmp.active = true;

            Debug.Log("Drogas Test");
            DepthOfField tmp2;
            camara_efectos.GetComponent<Volume>().profile.TryGet<DepthOfField>(out tmp2);
            tmp2.active = true;

        }

        if ((Time.time - TiempoDroga) > 25.0f && drogas && (Time.time - TiempoDroga) < 30.0f)
        {
            Debug.Log("Drogas Test");
            MotionBlur tmp3;
            camara_efectos.GetComponent<Volume>().profile.TryGet<MotionBlur>(out tmp3);
            tmp3.active = true;

            Debug.Log("Drogas Test");
            ColorAdjustments tmp4;
            camara_efectos.GetComponent<Volume>().profile.TryGet<ColorAdjustments>(out tmp4);
            tmp4.active = true;

            Debug.Log("Drogas Test");
            ChromaticAberration tmp5;
            camara_efectos.GetComponent<Volume>().profile.TryGet<ChromaticAberration>(out tmp5);
            tmp5.active = true;

            //Activar la opcion de bailar luego de volar pero aun no tenemos el volar jeje
            Luis.GetComponent<LogicaLuisNPC>().dialogo1 = true;


        }
        /*

        if ((Time.time - TiempoDroga) > 30.0f && drogas && !vomito)
        {
            Debug.Log("Drogas vomito");

            if ((Time.time - TiempoDroga > 40.0f))
            {
                Debug.Log("A vomitar vomito");
                boca_vomito.SetActive(true);
                ParticleSystem myParticles = boca_vomito.GetComponent<ParticleSystem>();
                AudioSource _audiosource = boca_vomito.GetComponent<AudioSource>();
                if (!_audiosource.isPlaying)
                {
                    _audiosource.Play();
                }

                if (!myParticles.isPlaying)
                {
                    myParticles.Play();
                }

                if ((Time.time - TiempoDroga) > 45.0f)
                {
                    myParticles.Stop();
                    boca_vomito.SetActive(false);
                    vomito = true;
                }

            }


        }


        if (temperatura_usuario > 40.0f)
        {
            //Audio de pitido
            pitidos.Play();

            //Se agrega color , maximo es tipo 0.85

            Debug.Log("Temperatura alta");

            Vignette tmp4;
            camara_efectos.GetComponent<Volume>().profile.TryGet<Vignette>(out tmp4);
            tmp4.active = true;
        }

        else if (temperatura_usuario > 38.0f)
        {
            Debug.Log("Comienza a subir temperatura");

            //Agregar vineta
        }
        if (drogas)
        {
            if ((Time.time - SavedTiempoDroga) > DelayTiempoDroga)
            {
                SavedTiempoDroga = Time.time;

                //Anything in here will be called every one second
                //


                temperatura_usuario = temperatura_usuario + 0.2f;

                Debug.Log("Temperatura sube por drogas a " + temperatura_usuario);
                StartCoroutine(PostData_Coroutine());
            }
        }

        if (baile)
        {
            if ((Time.time - SavedTiempoBaile) > DelayTiempoBaile)
            {
                SavedTiempoBaile = Time.time;

                //Anything in here will be called every one second
                //
                Debug.Log("Temperatura sube por por baile");

                temperatura_usuario = temperatura_usuario + 0.05f;

                StartCoroutine(PostData_Coroutine());
            }
        }
        */

    }
}

