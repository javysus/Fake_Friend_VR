using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class efects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vignette tmp;
        GetComponent<Volume>().profile.TryGet<Vignette>(out tmp);
        tmp.active = true;
    }

}
