using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaConiNPC : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panelHablar;
    public GameObject panelHablar2;
    public GameObject jugador;
    public GameObject dialogo;

    public Transform Target;
    public bool abrazo;
    private Animator animador;
    public bool culturaChupistica = false;
    public bool dialogoConi = false;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && abrazo)
        {
            Debug.Log("Hola,entre");
            panelHablar.SetActive(true);

            //animador = GetComponent<Animator>();
            //animador.SetTrigger("abrazar");

            panelHablar.LeanScale(Vector3.one, 1f);

            if (culturaChupistica)
            {
                dialogo.transform.LookAt(new Vector3(0f, Target.position.y, 0f));
            }
            else
            {
                transform.LookAt(new Vector3(Target.position.x, transform.position.y, Target.position.z));

            }
        } else if (other.CompareTag("Player") && dialogoConi){
            panelHablar2.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (culturaChupistica)
            {
                dialogo.transform.LookAt(new Vector3(0f, Target.position.y, 0f));
            }
            else
            {
                transform.LookAt(new Vector3(Target.position.x, transform.position.y, Target.position.z));

            }
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

    /*private IEnumerator Rotate()
    {
        WaitForSeconds Wait = new WaitForSeconds(1f / TicksPerSecond);

        while (True)
        {
            if (!Pause)
            {
                transform.Rotate(Vector3.up * RotationAmount);
            }

            yield return Wait;
        }


    }*/
}
