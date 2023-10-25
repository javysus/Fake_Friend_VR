using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscarLargoPlazo : MonoBehaviour
{
    public GameObject panelHablar;
    public Transform Target;
    public bool pedirAyudaDecision=false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetTrigger("sentarse");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && pedirAyudaDecision)
        {
            //animador.SetTrigger("HablarCollider");
            panelHablar.SetActive(true);
            panelHablar.LeanScale(Vector3.one, 1f);
            panelHablar.transform.LookAt(new Vector3(-Target.position.x, panelHablar.transform.position.y, Target.position.z));

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && pedirAyudaDecision)
        {
            panelHablar.transform.LookAt(new Vector3(-Target.position.x, panelHablar.transform.position.y, Target.position.z));

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && pedirAyudaDecision)
        {
            panelHablar.LeanScale(Vector3.zero, 1f).setEaseInOutExpo();
            //panelHablar.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
