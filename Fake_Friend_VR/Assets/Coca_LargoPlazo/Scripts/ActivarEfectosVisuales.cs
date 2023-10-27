using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class ActivarEfectosVisuales : MonoBehaviour
{
    // Start is called before the first frame update
    public movimiento_control movimiento;
    void Start()
    {
        DepthOfField tmp;
        GetComponent<Volume>().profile.TryGet<DepthOfField>(out tmp);
        tmp.active = true;

        MotionBlur tmp2;
        GetComponent<Volume>().profile.TryGet<MotionBlur>(out tmp2);
        tmp2.active = true;

        movimiento.moveSpeed = 0.8f;

        /*GetComponent<ShakeableTransform>().enabled = true;
        GetComponent<ShakeableTransform>().frequency = 20f;
        GetComponent<ShakeableTransform>().maximumAngularShake = new Vector3(.5f, .5f, .5f);*/
    }

}
