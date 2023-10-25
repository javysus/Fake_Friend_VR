using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SillaControlador : MonoBehaviour
{
    public GameObject panelHablar;
    
    public Transform Target;

    public float size = 0.01f;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Player"))
        {
            //animador.SetTrigger("HablarCollider");
            panelHablar.SetActive(true);
            panelHablar.LeanScale(new Vector3(-size,size,size), 1f);
            panelHablar.transform.LookAt(new Vector3(-Target.position.x, panelHablar.transform.position.y, Target.position.z));

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelHablar.transform.LookAt(new Vector3(-Target.position.x, panelHablar.transform.position.y, Target.position.z));

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelHablar.LeanScale(Vector3.zero, 1f).setEaseInOutExpo();
            //panelHablar.SetActive(false);
        }
    }
}
