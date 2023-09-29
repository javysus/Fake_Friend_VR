using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityStandardAssets.Vehicles.Car;

public class Choque : MonoBehaviour
{
    public AudioSource llantos_perro;
    public AudioSource freno_auto;
    public AudioSource llanto_mujer;
    public AudioSource car_hit;
    public AudioSource dog_scream;
    public AudioSource latidos;
    public GameObject panelNegro;
    public GameObject auto;
    public GameObject jugador;
    public GameObject sangre;
    public GameObject EndGame;
    public Transform perro;
    public Animator cami;

    private void Start()
    {
        cami.SetTrigger("sentarse");
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(MomentoChoque());
    }

    public IEnumerator MomentoChoque()
    {
        GetComponent<BoxCollider>().enabled = false;
        panelNegro.SetActive(true);
        car_hit.Play();
        dog_scream.Play();
        freno_auto.Play();
        jugador.GetComponent<LocomotionSystem>().enabled = true;
        jugador.GetComponent<ActionBasedContinuousTurnProvider>().enabled = true;
        jugador.GetComponent<HeredaXR>().enabled = true;
        jugador.GetComponent<CharacterController>().enabled = true;
        jugador.transform.SetParent(null);
        jugador.transform.position = new Vector3(0f, 1.25f, -11f);
        jugador.transform.rotation = new Quaternion(0, 90, 0, 0);
        auto.GetComponent<CarUserControl>().Speed = 0;
        yield return new WaitForSeconds(3);
        EndGame.SetActive(true);
        llantos_perro.Play();
        llanto_mujer.Play();
        latidos.Play();
        auto.transform.position = new Vector3(-0.98f, 1.01f, -11.22f);
        auto.transform.localRotation = Quaternion.Euler(0, 160, 0);
        perro.position = new Vector3(0.74f, 1.06f, -19.45686f);
        perro.localRotation = Quaternion.Euler(0, 90, -90);
        cami.ResetTrigger("sentarse");
        cami.SetTrigger("bajarseAuto");
        sangre.SetActive(true);
        panelNegro.SetActive(false);
    }


}
