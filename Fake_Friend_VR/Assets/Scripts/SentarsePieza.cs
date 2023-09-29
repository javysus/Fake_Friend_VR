using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentarsePieza : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Cami;
    public GameObject panelDialogo;
    public Animator CamiAnimator;
    public MeshCollider sillaCollider;
    public GameObject panelSentarse;
    public MeshRenderer pantallaMac;
    public Material facebook;
    public AudioSource llanto;
    private Vector3 posicionSentarse = new Vector3(6.15500021f, 0.75f, 15.3470001f);
    private Vector3 posicionPararse = new Vector3(5.34399986f, 0.949000001f, 15.5410004f);

    private void OnTriggerEnter(Collider other)
    {
        panelSentarse.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        panelSentarse.SetActive(false);
    }

    public void sentarseEscritorio()
    {
        Cami.transform.position = posicionSentarse;
        //Cami.transform.Rotate(0, 270, 0);
        //Cami.transform.rotation = new Quaternion(0, 270, 0, 0);
        Cami.transform.localRotation = Quaternion.Euler(0, 180, 0);
        CamiAnimator.SetTrigger("sentarse");
        pantallaMac.material = facebook;

        //Mover la silla
        sillaCollider.enabled = false;
        panelDialogo.SetActive(true);
    }

    public IEnumerator secuenciaLlorarYpararse()
    {
        llanto.Play();
        yield return new WaitForSeconds(7);
        Cami.transform.position = posicionPararse;
        CamiAnimator.SetTrigger("idle");
        Cami.transform.localRotation = Quaternion.Euler(0, 270, 0);
        llanto.Stop();
    }

    public void llorarYpararse()
    {
        panelDialogo.SetActive(false);
        StartCoroutine(secuenciaLlorarYpararse());
    }

    
}
