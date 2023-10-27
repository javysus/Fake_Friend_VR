using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandShake : MonoBehaviour
{
    private Controlador controlador;
    private float tiempo;
    private bool shake = false;
    private void Start()
    {
        controlador = GetComponent<Controlador>();
        tiempo = Time.time;
    }

    public void shakeXpositive()
    {
        controlador.leftHand.trackingPositionOffset.x += 0.01f;
        controlador.leftHand.trackingRotationOffset.x += 5f;
        controlador.rightHand.trackingPositionOffset.x += 0.01f;
        controlador.rightHand.trackingRotationOffset.x += 5f;
        shake = true;
    }

    public void shakeXnegative()
    {
        controlador.leftHand.trackingPositionOffset.x -= 0.01f;
        controlador.leftHand.trackingRotationOffset.x -= 5f;
        controlador.rightHand.trackingPositionOffset.x -= 0.01f;
        controlador.rightHand.trackingRotationOffset.x -= 5f;
        shake = false;
    }

    private void Update()
    {
        if (!shake)
        {
            Debug.Log("Entre en el primero");
            shakeXpositive();
            tiempo = Time.time;
        }

        else if (shake)
        {
            Debug.Log("Entre en el segundo");
            shakeXnegative();
            tiempo = Time.time;
        }
    }

}
