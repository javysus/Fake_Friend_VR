using DS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetivosIzq : MonoBehaviour
{
    public int numDeObjetivos1;
    public GameObject objizq1;
    public GameObject objizq2;
    public GameObject Luis;
    public GameObject NextController;
    public GameObject DialogoPerdio;
    public GameObject DialogoGanar;
    public bool ganar = false;
    public bool perder = false;
    public float tiempo_i;
    public float tiempo_f;
    public Animator jugador;
    // Start is called before the first frame update
    void Start()
    {
        tiempo_i = Time.time;
        numDeObjetivos1 = 4;
        objizq1.SetActive(true);
        objizq2.SetActive(false);
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (numDeObjetivos1==0)
        {
            tiempo_f = Time.time;
            
            if ((tiempo_f-tiempo_i)>6.0f)
            {
                perder = true;
                if (perder)
                {
                    DialogoPerdio.GetComponent<DSDialogue>().StartDialogue("MauroMC2");
                    perder = false;
                    Debug.Log("Dialogo de perdio");
                    numDeObjetivos1 = -1;
                    
                    
                }
                

            }
            else
            {
                ganar = true;
                if (ganar)
                {
                    //dialogo ganar
                    DialogoGanar.GetComponent<DSDialogue>().StartDialogue("MauroMC2");
                    ganar = false;
                    Debug.Log("Dialogo de gano");
                    numDeObjetivos1 = -1;
                    
                    
                }
            }
            objizq1.SetActive(false);
            objizq2.SetActive(false);

            //Fin del juego
            Debug.Log("Se activa boton de Luis");
            if (Luis)
            {
                Luis.GetComponent<LogicaLuisNPC>().dialogo2 = true;
                NextController.SetActive(true);
            }
            //activar dialogo mauro
            
            
            
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.tag == "ObjetivoIzq") && (numDeObjetivos1%2 == 0))
        {
            objizq1.SetActive(false);
            objizq2.SetActive(true);
            numDeObjetivos1--;
            if (numDeObjetivos1<=0)
            {
                Debug.Log("Fin baile izq");
            }
            
        }
        else if ((col.gameObject.tag == "ObjetivoIzq") && (numDeObjetivos1%2 != 0))
        {
            objizq1.SetActive(true);
            objizq2.SetActive(false);
            numDeObjetivos1--;
            if (numDeObjetivos1<=0)
            {
                Debug.Log("Fin baile izq");
            }
            
        }
    }
}
