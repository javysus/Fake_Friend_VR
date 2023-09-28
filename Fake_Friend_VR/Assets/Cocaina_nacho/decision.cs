using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decision : MonoBehaviour
{
    // Start is called before the first frame update
    public efectos_coca efectos;
    public GenerarNpc generar;
    bool max;
    public GameObject panel_desmayo;
    public GameObject desactivar;
    public llevar_guardia guardia;
    public recibir_empuje amigo1;
    public recibir_empuje amigo2;
    public GameObject panel_puerta;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void select1()
    {

        generar.GenerarPersonajesEnSuelo();
        efectos.maximo = true;
        StartCoroutine(activar_desmayo());
        desactivar.SetActive(false);
        panel_puerta.SetActive(false);


    }
    public void select2()
    {
        amigo1.enabled = true;
        amigo2.enabled = true;
        desactivar.SetActive(false);
        //guardia.enabled = true;

    }

    private IEnumerator activar_desmayo()
    {
        yield return new WaitForSeconds(10.0f); // Espera durante el tiempo especificado

        // Desactiva el objeto después del tiempo especificado
        panel_desmayo.SetActive(true);
    }
}
