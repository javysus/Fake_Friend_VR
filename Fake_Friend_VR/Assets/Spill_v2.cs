using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spill_v2 : MonoBehaviour
{
    ParticleSystem myParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        myParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Angle(Vector3.up, transform.forward) <= 90f)
        {
            myParticleSystem.Play();
        }
        else
        {
            myParticleSystem.Stop();
        }
    }
}
