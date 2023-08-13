using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using DatosUsuario;
using UnityEngine.Networking;

public class TapWater : MonoBehaviour
{
    ParticleSystem myParticleSystem;
    AudioSource _audioSource;
    public GameObject Particulas;
    //ml de agua a tomar por segundo
    float agua_usuario;
    float ml = 60f;
    float ml_total = 0f;
    string uri_get;
    string uri_update;
    int id_usuario = 1;
    int id_sustancia = 1;
    // Start is called before the first frame update
    void Start()
    {
        myParticleSystem = Particulas.GetComponent<ParticleSystem>();
        _audioSource = Particulas.GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        uri_get = "https://2073-200-124-49-206.ngrok-free.app/datossesionusuario?id_usuario=" + id_usuario + "&id_sustancia=" + id_sustancia;
        uri_update = "https://2073-200-124-49-206.ngrok-free.app/updatedatos?id_usuario=" + id_usuario + "&id_sustancia=" + id_sustancia;
    }

    void Update()
    {
        if(myParticleSystem.isPlaying && !_audioSource.isPlaying)
        {
            _audioSource.Play();
        };
    }

    // Update is called once per frame
    public void ActivarDesactivarAgua()
    {

        bool isPlaying = !myParticleSystem.isPlaying;
        SetPlay(isPlaying);

    }

    IEnumerator GetData_Coroutine()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(uri_get))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log("Error al consultar a la base de datos");
            }
            else
            {
                Debug.Log("Test " + request.downloadHandler.text);
                var desData = JsonConvert.DeserializeObject<Root>(request.downloadHandler.text);

                var sesion = desData.sesion;

                agua_usuario = float.Parse(sesion.agua_organismo, CultureInfo.InvariantCulture.NumberFormat);
                Debug.Log("Test Agua grifo" + agua_usuario);
            }
        }
    }

    IEnumerator PostData_Coroutine()
    {
        WWWForm form = new WWWForm();
        form.AddField("agua_organismo", (agua_usuario + ml_total).ToString());
        float aguita = agua_usuario + ml_total;
        Dictionary<string, string> headers = form.headers;
        byte[] rawData = form.data;

        byte[] myData = System.Text.Encoding.UTF8.GetBytes("{\"agua_organismo\": \"" + aguita.ToString() + "\"}");
        using (UnityWebRequest request = UnityWebRequest.Put(uri_update, rawData))
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

                //Reiniciar variables al actualizar el agua ingerida
                ml = 0f;
            }
        }
    }

    public void SetPlay(bool value)
    {
        if (value)
        {
            myParticleSystem.Play();
            _audioSource.Play();
        }
        else
        {
            myParticleSystem.Stop();
            _audioSource.Stop();
        }
    }

    [ContextMenu("DrinkFromTap")]
    public void DrinkFromTap()
    {
        if (myParticleSystem.isPlaying)
        {
            ml_total = ml_total + ml; //Se agrega por segundo
            Debug.Log("Test Personaje ha tomado " + ml_total);
        }
    }

    [ContextMenu("ActualizarPersonaje")]
    public float ActualizarPersonaje()
    {
        //Actualizar valor de ml de personaje
        StartCoroutine(GetData_Coroutine()); //Obtiene el agua actual

        StartCoroutine(PostData_Coroutine()); //Actualiza el agua consumida

        float ml_enviar = ml_total;
        //Reiniciar ml total consumido del grifo
        ml_total = 0f;

        return ml_enviar;
    }
}
