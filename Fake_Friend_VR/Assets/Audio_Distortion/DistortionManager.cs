using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DistortionManager : MonoBehaviour
{

    public AudioMixerSnapshot normal;
    public AudioMixerSnapshot drugged;
    public AudioMixerSnapshot overhyd;

    Canvas canvas;

    int status = 0;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && status == 0)
        {
            canvas.enabled = !canvas.enabled;
            drugged.TransitionTo(.01f);
            status = 1;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && status == 1)
        {
            canvas.enabled = !canvas.enabled;
            overhyd.TransitionTo(.01f);
            status = 2;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && status == 2)
        {
            canvas.enabled = !canvas.enabled;
            drugged.TransitionTo(.01f);
            status = 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && status == 1)
        {
            canvas.enabled = !canvas.enabled;
            normal.TransitionTo(.01f);
            status = 0;
        }
    }
}
