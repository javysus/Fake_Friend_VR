using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandeja_Comida : MonoBehaviour
{
    // Start is called before the first frame update
    public Trigger_dialogos trigger;
    public GameObject mano_der;
    public GameObject panelNPC;

    float TiempoMensaje = 0f;

    void Start()
    {
        mano_der = GameObject.FindGameObjectWithTag("Player");
        panelNPC.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entro en el triggerEnter");
        if (other.tag == "Player")
        {
            Debug.Log("Entro en el PLayer");
            panelNPC.SetActive(true);
            trigger.StartDialogue();
            TiempoMensaje = Time.time;
        }
    }

    void Update()
    {
        if ((Time.time - TiempoMensaje) > 5.0f){
            panelNPC.SetActive(false);
        }
    }
}
