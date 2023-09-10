using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulasAguita2 : MonoBehaviour
{
    ParticleSystem myParticleSystem;
    //public GameObject ObjAgua;
    float nivel;
    private float vector;
    public bool IsFinished = false;
    public GameObject Particulas;
    // Start is called before the first frame update
    void Start()
    {
        myParticleSystem = Particulas.GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        vector = Vector3.Angle(Vector3.down, transform.forward);
        //Debug.Log("Vector " + vector);
        //Debug.Log("Test nivel de agua " + nivel);
        Debug.Log("Wena " + IsFinished);
        if ((vector >= 115f) && !IsFinished)
        {
            if (!myParticleSystem.isPlaying)
            {
                myParticleSystem.Play();
            }


        } else if ((vector <= 115f) || IsFinished)
        {
            if (myParticleSystem.isPlaying) //Si se acaba el agua o se deja de tomar agua
            {
                myParticleSystem.Stop();
            }
        }
        else
        {
            if (myParticleSystem.isPlaying) //Si se acaba el agua o se deja de tomar agua
            {
                myParticleSystem.Stop();
                //IsFinished = true;
                //Actualizar en la base de datos el valor de ml del usuario + el ml tomado ahora
            }
        }
    }
}
