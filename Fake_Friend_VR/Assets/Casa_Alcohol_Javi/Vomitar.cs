using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vomitar : MonoBehaviour
{
    public Animator CamiAnimator;
    public GameObject XRRig;
    static Vector3 posicionVomitar = new Vector3(10.2939997f, 0.949000001f, 18.7240009f);
    public GameObject vomito;
    public GameObject caminoLuz;

    private float TiempoVomito = 0f;
    private bool vomitando = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - TiempoVomito) > 4.0f && vomitando)
        {
            Debug.Log("DEBUG Se acaba el vomito");
            vomitando = false;
            //Se para el vomito
            vomito.GetComponent<ParticleSystem>().Stop();
            vomito.GetComponent<AudioSource>().Stop();

            CamiAnimator.SetTrigger("idle");

            this.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            caminoLuz.SetActive(false);
            XRRig.transform.position = posicionVomitar;
            XRRig.transform.localRotation = Quaternion.Euler(0, 0, 0);
            CamiAnimator.SetTrigger("vomitar");

            //Activar vomito
            Debug.Log("DEBUG Comienza a vomitar");
            vomitando = true;
            TiempoVomito = Time.time;
            vomito.GetComponent<ParticleSystem>().Play();
            vomito.GetComponent<AudioSource>().Play();

            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
