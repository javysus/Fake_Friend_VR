using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VomitarLargoPlazo : MonoBehaviour
{
    public CamiControllerAlcoholica CamiController;
    public GameObject XRRig;
    public Vector3 posicionVomitar = new Vector3(4.24800014f, 0.32100001f, 5.74499989f);
    public GameObject vomito;
    public GameObject caminoToilet;

    private float TiempoVomito = 0f;
    private bool vomitando = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator FinVomito()
    {
        //Wait
        yield return new WaitForSeconds(2);

        //Load scene
        vomito.GetComponent<ParticleSystem>().Stop();
        vomito.GetComponent<AudioSource>().Stop();
    }

private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Desactivar camino de luz
            caminoToilet.SetActive(false);

            XRRig.transform.position = posicionVomitar;
            XRRig.transform.localRotation = Quaternion.Euler(0, 0, 0);

            CamiController.Vomitar();
            //Activar vomito
            Debug.Log("DEBUG Comienza a vomitar");
            vomitando = true;
            TiempoVomito = Time.time;
            vomito.GetComponent<ParticleSystem>().Play();
            vomito.GetComponent<AudioSource>().Play();

            GetComponent<BoxCollider>().enabled = false;

            StartCoroutine(FinVomito());

        }
    }
}
