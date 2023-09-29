using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class efectos_coca : MonoBehaviour
{
    public GameObject camara_efectos;
    public bool iniciar;
    public bool aumentar;
    public bool maximo;
    public Bloom tmp;

    
    public AudioMixerSnapshot drugged;
    public AudioMixerSnapshot moredrugged;
    public AudioMixerSnapshot overhyd;

    public AudioSource latidos;
    public AudioSource respiracion;

    public GenerarNpc crear_npc;
    public GameObject panel_decision;
    // Start is called before the first frame update

    void Start()
    {
        
        camara_efectos.GetComponent<Volume>().profile.TryGet<Bloom>(out tmp);
        
    }
    void Update()
    {
        if (iniciar)
        {
            StartCoroutine(InvokeActivar(tmp, 5.0f));
            iniciar = false;
        }
        if (aumentar)
        {
            StartCoroutine(InvokeAumentar(tmp, 15.0f));
            aumentar = false;
        }
        if (maximo)
        {
            StartCoroutine(InvokeMaximo(tmp, 0.5f));
            maximo = false;
        }

    }

    // Update is called once per frame
    void activar_efecto(Bloom tmp)
    {
        tmp.active = true;
        drugged.TransitionTo(0.1f);
        latidos.Play();
        respiracion.Play();
        

    }

    void aumentar_efecto(Bloom tmp){
        tmp.intensity.Override(20.0f);
        moredrugged.TransitionTo(.01f);
        latidos.volume = 0.8f;
        respiracion.volume = 0.8f;
        crear_npc.activar_mirada = true;
        panel_decision.SetActive(true);
    }

    void maximo_efecto(Bloom tmp)
    {
        tmp.intensity.Override(30.0f);
        overhyd.TransitionTo(.01f);
        latidos.volume = 0.99f;
        respiracion.volume = 0.99f;
    }

    IEnumerator InvokeActivar(Bloom parametro, float retraso)
    {
        yield return new WaitForSeconds(retraso);
        activar_efecto(parametro);
    }

    IEnumerator InvokeAumentar(Bloom parametro, float retraso)
    {
        yield return new WaitForSeconds(retraso);
        aumentar_efecto(parametro);
    }

    IEnumerator InvokeMaximo(Bloom parametro, float retraso)
    {
        yield return new WaitForSeconds(retraso);
        maximo_efecto(parametro);
    }
}
