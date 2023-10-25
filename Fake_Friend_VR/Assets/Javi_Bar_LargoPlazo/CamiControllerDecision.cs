using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamiControllerDecision : MonoBehaviour
{
    public GameObject ColliderPieza;
    public GameObject ColliderPuerta;

    public PlayerSit ps;
    public GameObject celular;
    public GameObject Pantalla;
    public Material expulsion;

    public GameObject Hermano;
    public GameObject decisiones;
    public GameObject botonLevantarse;

    public GameObject caminoPuerta;
    public GameObject caminoHermano;

    public CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        SitDown();
    }

    void SitDown()
    {
        //GetComponent<Animator>().SetTrigger("sentarse");
        ps.SitDown();
    }

    public void SitUp()
    {
        //Activar notificacion de celular
        celular.GetComponent<AudioSource>().Play();
        ps.SitUp();

        botonLevantarse.SetActive(false);

        cc.center = new Vector3(-0.06f, 0.35f, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    //Cambia el material del celular al tomarlo con el correo de expulsion
    public void correoExpulsion()
    {
        Pantalla.GetComponent<MeshRenderer>().material = expulsion;
    }

    //Cuando lo deja comienza el otro flujo
    public void dejarCelular()
    {
        ColliderPieza.SetActive(true);
    }

    public void irAlBar()
    {
        //Activar camino de luz
        caminoPuerta.SetActive(true);

        //Activar boton para irse
        ColliderPuerta.SetActive(true);

        decisiones.SetActive(false);
    }

    public void pedirAyuda()
    {
        //Activar camino de luz
        caminoHermano.SetActive(true);

        //Activar boton de hermano
        Hermano.GetComponent<BoxCollider>().enabled=true;

        decisiones.SetActive(false);

        Hermano.GetComponent<OscarLargoPlazo>().pedirAyudaDecision = true;
    }
}
