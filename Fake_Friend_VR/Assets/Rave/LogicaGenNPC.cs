using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaGenNPC : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject panelHablar;
    public Transform Target;
    private Animator animador;
    public GameObject botella;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hola,entre");
            //animador = GetComponent<Animator>();
            //animador.SetTrigger("HablarCollider");
            panelHablar.LeanScale(Vector3.one, 0.5f);
            transform.LookAt(new Vector3(Target.position.x, transform.position.y, Target.position.z));
            //panelHablar.transform.localScale = new Vector3(panelHablar.transform.localScale.x, panelHablar.transform.localScale.y, panelHablar.transform.localScale.z);
            //panelHablar.transform.LookAt(new Vector3(Target.position.x, 0, Target.position.z));
            //panelHablar.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            //animador = GetComponent<Animator>();
            //animador.SetTrigger("HablarCollider");

            transform.LookAt(new Vector3(Target.position.x, transform.position.y, Target.position.z));
            //panelHablar.transform.LookAt(new Vector3(Target.position.x, panelHablar.transform.position.y, Target.position.z));
            //panelHablar.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hola,me sali");
            panelHablar.LeanScale(Vector3.zero, 1f).setEaseInOutExpo();
            //panelHablar.SetActive(false);
        }
    }

    public void venderBotella()
    {
        GetComponent<Animator>().SetTrigger("dar");
        botella.SetActive(true);
    }
}