using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class activar_cinematica : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public CustomTracked customTracked;
    public CustomMove mover_personaje;
    public GameObject panel_sentarse;

    // Start is called before the first frame update
    void Start()
    {
        panel_sentarse.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activa la cinemática solo si el objeto tiene el tag deseado
            panel_sentarse.SetActive(true);
            Debug.Log("activar cinematica");
        }
    }

    public void sentarse()
    {
        Debug.Log("A sentarse");
        mover_personaje.moveSpeed = 0.0f;
        customTracked.trackingType = UnityEngine.InputSystem.XR.TrackedPoseDriver.TrackingType.RotationOnly;
        playableDirector.Play();
    }
    
}
