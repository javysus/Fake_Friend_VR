using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamaController : MonoBehaviour
{
    public GameObject panelHablar;

    public GameObject mama;

    public Transform Target;

    public float size = 0.01f;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            //animador.SetTrigger("HablarCollider");
            panelHablar.SetActive(true);
            panelHablar.LeanScale(new Vector3(-size, size, size), 1f);
            panelHablar.transform.LookAt(new Vector3(Target.position.x, panelHablar.transform.position.y, Target.position.z));

            mama.transform.LookAt(Target);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //panelHablar.SetActive(false);
            panelHablar.transform.LookAt(new Vector3(Target.position.x, panelHablar.transform.position.y, Target.position.z));

            mama.transform.LookAt(Target);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hola,me sali");
            panelHablar.LeanScale(Vector3.zero, 1f).setEaseInOutExpo();
            panelHablar.SetActive(false);
        }
    }
}