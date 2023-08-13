using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDialogo : SistemaDialogo
{
    float tiempo;
    // Start is called before the first frame update
    void Start()
    {
        tiempo = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;

        if (tiempo >= 5000)
        {
            ConfirmarUI();
        }
    }
}
