using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flujo_historia : MonoBehaviour
{
    // Start is called before the first frame update
    public nav_control amigo1;
    public nav_control amigo2;
    public GameObject panel1;
    
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void mover_destino()
    {
        
        amigo1.animacion.ResetTrigger("idle");
        amigo1.animacion.SetTrigger("start_walk");
        amigo1.MoverAlDestinoSiguiente();
        //------------
        amigo2.animacion.ResetTrigger("idle");
        amigo2.animacion.SetTrigger("start_walk");
        amigo2.MoverAlDestinoSiguiente();

        panel1.SetActive(false);
        //aparecer_npc.activar_mirada = true;
    }

    
    
}
