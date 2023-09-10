using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.AccessControl;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.UI;

public class RelojDigital : MonoBehaviour
{
    [Tooltip("Tiempo inicial en segundos")]
    public int tiempoInicial;

    [Tooltip("Escala del tiempo del reloj")]
    [Range(-100.0f, 100.0f)]
    public float escalaDeTiempo = 1;

    [Tooltip("Sonido al cambiar minutos")]
    //[SerializeField] private AudioSource sonidoMinutos;

    private Text myText;
    private float tiempoDelFrameConTimeScale = 0f;
    private float tiempoAMostrarEnSegundos = 0f;
    private float escalaDeTiempoAlPausar, escalaDeTiempoInicial;
    private bool estaPausado = false;

    private int minutosFrameAnterior = -1;
    public AudioSource miAudioSource;

    public delegate void AccionCambioMinutos();
    public static event AccionCambioMinutos AlCambiarMinutos;

    private void OnEnable()
    {
        RelojDigital.AlCambiarMinutos += SonidoAlCambiarMinutos;
    }
    private void OnDisable()
    {
        RelojDigital.AlCambiarMinutos -= SonidoAlCambiarMinutos;
    }

    // Start is called before the first frame update
    void Start()
    {
        escalaDeTiempoInicial = escalaDeTiempo;

        myText = GetComponent<Text>();

        
            //miAudioSource = this.gameObject.AddComponent<AudioSource>();
        miAudioSource.Play();
            //miAudioSource.playOnAwake = false;

        tiempoAMostrarEnSegundos = tiempoInicial;

        ActualizarReloj(tiempoInicial);
    }

    // Update is called once per frame
    void Update()
    {
        tiempoDelFrameConTimeScale = Time.deltaTime * escalaDeTiempo;
        tiempoAMostrarEnSegundos += tiempoDelFrameConTimeScale;
        ActualizarReloj(tiempoAMostrarEnSegundos);
        
        
    }

    public void ActualizarReloj(float tiempoEnSegundos)
    {
        int horas = 0;
        int minutos = 0;
        int segundos = 0;
        string textoDelReloj;

        if (tiempoEnSegundos < 0) tiempoEnSegundos = 0;

        horas = (int)tiempoEnSegundos / 3600;
        minutos = ((int)tiempoEnSegundos - horas*3600) / 60;
        segundos = (int)tiempoEnSegundos % 60;

        textoDelReloj = horas.ToString("00 ") + ":" + minutos.ToString(" 00 ") + "\n" + segundos.ToString(" 00");

        myText.text = textoDelReloj;

        if(minutosFrameAnterior > -1)
        {
            if(minutos != minutosFrameAnterior)
            {
                if(AlCambiarMinutos != null)
                {
                    AlCambiarMinutos();
                }
                minutosFrameAnterior = minutos;
            }
        }
        else
        {
            minutosFrameAnterior = minutos;
        }
    }
    void SonidoAlCambiarMinutos()
    {
        miAudioSource.Play();
        
    }
}
