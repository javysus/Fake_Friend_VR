using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.SocialPlatforms;
using DS;
public class inhalar_2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float range;
    bool look;
    public LayerMask capaplayer;
    public control_coca_multiple multiple;
    public AudioSource inhalar;
    public DialogueManagerMauroMC2 dialogo;
    public SacudirManos sacudirManos;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        look = Physics.CheckSphere(transform.position, range, capaplayer);
        if (look)
        {
            inhalar.Play();
            StartCoroutine(DesactivarDespuesDeTiempo(3.0f));
            multiple.consumir = true;
            //activar efectos primer consumo
            multiple.consumir_coca();
            multiple.activar_bloom(15.0f);
            multiple.aumentar_intensidad(15.0f);
            //disociar camara
            multiple.aumentar_velocidad(2.3f);
            multiple.cambiar_volumen(0.95f);
            multiple.cambio_camara();
            sacudirManos.enabled = true;

            dialogo.isActive = true;
            dialogo.NextMessage();


        }
        else
        {
            ;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private IEnumerator DesactivarDespuesDeTiempo(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);

        // Desactiva el objeto
        gameObject.SetActive(false);
    }
}
