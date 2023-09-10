using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using DatosUsuario;
using UnityEngine.Networking;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class DrinkAlcohol : MonoBehaviour
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

    //Cuanto ml ha tomado del tap
    float ml_tap = 0f;

    // Start is called before the first frame update
    bool vomito = false;
    void Start()
    {
        _collider = GetComponent<Collider>();
        //_collider.isTrigger = true;

        uri_get = "https://2073-200-124-49-206.ngrok-free.app/datossesionusuario?id_usuario=" + id_usuario + "&id_sustancia=" + id_sustancia;
        uri_update = "https://2073-200-124-49-206.ngrok-free.app/updatedatos?id_usuario=" + id_usuario + "&id_sustancia=" + id_sustancia;

        //StartCoroutine(GetData_Coroutine());
    }

    /*
    IEnumerator GetData_Coroutine()
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
    }*/

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
            GameObject.Find("Pill_3").SetActive(false);

        }

        //Vaso de agua
        Spill2 consumable = game.GetComponent<Spill2>();
        Debug.Log("Test colision" + consumable);
        if (consumable != null && !consumable.IsFinished)
        {
            Debug.Log("Test colisiona con vaso ");
            consumable.Consume();
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


        if (consumable != null && !consumable.IsFinished)
        {
            Debug.Log("Test colision exit");

            
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
