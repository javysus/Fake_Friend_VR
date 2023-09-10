using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using DatosUsuario;
using UnityEngine.Networking;
public class Spill2 : MonoBehaviour
{
    ParticleSystem myParticleSystem;
    public Renderer _renderAgua;
    public GameObject ObjAgua;
    public GameObject Particulas;
    public GameObject CamaraMareos;
    float nivel;
    float ml = 0f; //Cantidad de agua tomada
    float ml_total = 255f; //Cantidad de agua del vaso
    public bool IsFinished = false;
    public static int cantVasos =0;
    float nivel_inicial = 0f;
    AudioSource _audioSource;
    int id_usuario = 1;
    int id_sustancia = 1;
    string uri_get;
    string uri_update;
    float agua_usuario;
    float temperatura_usuario;
    float nivel_inicial_in;
    public bool nuevo = true;

    public GameObject panelHablarDiego;
    public GameObject NextController2;
    // Start is called before the first frame update

    public GameObject NextController;
    float vector;
    void Start()
    {
        myParticleSystem = Particulas.GetComponent<ParticleSystem>();
        vector = Particulas.GetComponent<ParticulasAguita>().vector;
        _renderAgua = ObjAgua.GetComponent<Renderer>();

        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;

        nivel_inicial_in = _renderAgua.material.GetFloat("Vector1_a8cc7360c9dd401a876115a77d6c0cd5");
        uri_get = "https://2073-200-124-49-206.ngrok-free.app/datossesionusuario?id_usuario=" + id_usuario + "&id_sustancia=" + id_sustancia;
        uri_update = "https://2073-200-124-49-206.ngrok-free.app/updatedatosagua?id_usuario=" + id_usuario + "&id_sustancia=" + id_sustancia;

        nuevo = true;
        //StartCoroutine(GetData_Coroutine());
    }


    //Consumir agua
    [ContextMenu("Consume")]
    public void Consume()
    {
        vector = Particulas.GetComponent<ParticulasAguita>().vector;
        bool IsFinished = Particulas.GetComponent<ParticulasAguita>().IsFinished;
        if (vector <= 140f && (!IsFinished))
        {
            nivel = _renderAgua.material.GetFloat("Vector1_a8cc7360c9dd401a876115a77d6c0cd5");
            if (nivel > nivel_inicial)
            {
                nivel_inicial = _renderAgua.material.GetFloat("Vector1_a8cc7360c9dd401a876115a77d6c0cd5");
            }

            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }//
        }
    }

    //void GetData() => StartCoroutine(GetData_coroutine());
   /* IEnumerator GetData_Coroutine()
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

                var desData = JsonConvert.DeserializeObject<Root>(request.downloadHandler.text);

                var sesion = desData.sesion;

                agua_usuario = float.Parse(sesion.agua_organismo, CultureInfo.InvariantCulture.NumberFormat);
                Debug.Log("Test Agua " + agua_usuario);

            }
        }
    }

    IEnumerator PostData_Coroutine()
    {
        WWWForm form = new WWWForm();
        form.AddField("agua_organismo", (agua_usuario + ml).ToString());

        float aguita = agua_usuario + ml;
        Dictionary<string, string> headers = form.headers;
        byte[] rawData = form.data;

        //byte[] myData = System.Text.Encoding.UTF8.GetBytes(form);
        Debug.Log("Test agua en cuerpo " + aguita.ToString());
        byte[] myData = System.Text.Encoding.UTF8.GetBytes("{\"agua_organismo\": \"" + aguita.ToString() + "\"}");
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

                //Reiniciar variables al actualizar el agua ingerida
                ml = 0f;
            }
        }
    }

    //Actualizar agua del personaje en base de datos
    [ContextMenu("ActualizarPersonaje")]
    public void ActualizarPersonaje()
    {
        if (nivel_inicial > 0f)
        {
            float nivel_final = _renderAgua.material.GetFloat("Vector1_a8cc7360c9dd401a876115a77d6c0cd5");
            float nivel_consumido = nivel_inicial - nivel_final;
            ml = ml_total * nivel_consumido;

            Debug.Log("test Agua consumida " + ml);
            //Actualizar
            //StartCoroutine(GetData_Coroutine());

            //StartCoroutine(PostData_Coroutine());
        }
    }*/
    // Update is called once per frame
    void Update()
    {
        nivel = _renderAgua.material.GetFloat("Vector1_a8cc7360c9dd401a876115a77d6c0cd5");
        Debug.Log("Test nivel de agua " + nivel);
        if ((Vector3.Angle(Vector3.down, transform.up) <= 140f) && (nivel > 0f))
        {
            if (!myParticleSystem.isPlaying)
            {
                myParticleSystem.Play();
            }

            _renderAgua.material.SetFloat("Vector1_a8cc7360c9dd401a876115a77d6c0cd5", (nivel - 0.002f));

        }
        else if (nivel < 0f && nuevo)
        {
            if (myParticleSystem.isPlaying) //Si se acaba el agua o se deja de tomar agua
            {
                myParticleSystem.Stop();
                IsFinished = true;
                //Actualizar en la base de datos el valor de ml del usuario + el ml tomado ahora

                Debug.Log("Se termina el vasito");
                cantVasos++;
                if (cantVasos == 1)
                {
                    CamaraMareos.GetComponent<ShakeableTransform>().enabled = true;
                    NextController2.SetActive(true);
                    panelHablarDiego.SetActive(true);
                } else if (cantVasos == 2)
                {
                    CamaraMareos.GetComponent<ShakeableTransform>().maximumAngularShake = new Vector3(8, 8, 8);
                }
                
                NextController.SetActive(true);
                nuevo = false;
            }
        }
        else
        {
            if (myParticleSystem.isPlaying) //Si se acaba el agua o se deja de tomar agua
            {
                myParticleSystem.Stop();
                IsFinished = true;
                //Actualizar en la base de datos el valor de ml del usuario + el ml tomado ahora
            }
        }
    }
}
