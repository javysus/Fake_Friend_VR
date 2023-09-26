using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using DatosUsuario;
using UnityEngine.Networking;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

namespace DS
{
    public class DrinkAlcoholBar : MonoBehaviour
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

        //Objeto de camara Camara Offset
        public GameObject camara_efectos;
        public bool colisionVaso = false;
        public int vasos = 0;
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
                //Desactivar componente de pastilla
                GameObject.Find("Pill_3").SetActive(false);

            }

            //Vaso de agua
            if (other.tag == "Vaso")
            {
                Debug.Log("Test colisiona con vaso ");
                colisionVaso = true;
                game.GetComponent<AudioSource>().Play();
            }

        }

        void OnTriggerExit(Collider other)
        {
            //Vaso de agua
            GameObject game = other.gameObject;
            colisionVaso = false;

            if (other.tag == "Vaso")
            {
                colisionVaso = false;
                
            }

        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}