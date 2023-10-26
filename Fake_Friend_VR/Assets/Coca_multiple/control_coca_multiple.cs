using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class control_coca_multiple : MonoBehaviour
{
    public List<Light> luces;
    public GameObject camara_efectos;
    public AudioSource latidos;
    public AudioSource resp_agitada;
    public AudioSource suspiro;
    public AudioMixerSnapshot drugged;
    public AudioSource musica_pc;
    public bool consumir=false;
    public Camera main_camera;
    public Camera disociar;
    public movimiento_control control_mov;
    public Material sangrado;
    public Renderer rend;
    
    // Start is called before the first frame update

    public void consumir_coca()
    {
        drugged.TransitionTo(.01f);
        Invoke("suspirar", 1.5f);
        rend.material = sangrado;
        Invoke("latir", 2.8f);

    }
    public void activar_bloom(float valor)
    {
        Bloom tmp4;
        camara_efectos.GetComponent<Volume>().profile.TryGet<Bloom>(out tmp4);
        tmp4.active = true;
        tmp4.intensity.value = valor;

    }

    public void aumentar_intensidad(float valor)
    {
        foreach (Light luz in luces)
        {
            luz.intensity = valor;
        }
    }

    

    public void camara_disociar()
    {
        main_camera.depth = 0;
        disociar.depth = 2;
    }
    public void camara_main()
    {
        main_camera.depth = 2;
        disociar.depth = 0;
    }
    public void cambio_camara()
    {
        Invoke("camara_disociar", 2.0f);
        Invoke("camara_main", 7.0f);
    }

    public void aumentar_velocidad(float valor)
    {
        control_mov.moveSpeed = valor;
    }

    public void suspirar()
    {
        suspiro.Play();
    }

    public void cambiar_volumen(float valor)
    {
        musica_pc.volume = valor;
        latidos.volume = valor;
        resp_agitada.volume = valor;
    }
    public void latir()
    {
        latidos.Play();
        resp_agitada.Play();
    }
    
}
