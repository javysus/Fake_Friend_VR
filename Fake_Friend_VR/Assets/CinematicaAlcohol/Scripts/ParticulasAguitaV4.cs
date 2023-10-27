using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{
    public class ParticulasAguitaV4 : MonoBehaviour
    {
        ParticleSystem myParticleSystem;
        public Renderer _renderAgua;
        public GameObject ObjAgua;
        float nivel;
        public float vector;
        public bool IsFinished = false;
        // Start is called before the first frame update
        void Start()
        {
            myParticleSystem = GetComponent<ParticleSystem>();
            _renderAgua = ObjAgua.GetComponent<Renderer>();

        }

        // Update is called once per frame
        void Update()
        {
            nivel = _renderAgua.material.GetFloat("Vector1_a8cc7360c9dd401a876115a77d6c0cd5");
            vector = Vector3.Angle(Vector3.down, transform.forward);
            //Debug.Log("Vector " + vector);
            //Debug.Log("Test nivel de agua " + nivel);
            if ((vector <= 140f) && (nivel > 0f))
            {
                if (!myParticleSystem.isPlaying)
                {
                    myParticleSystem.Play();
                }

                if (FindObjectOfType<DrinkAlcoholCinematica>().colisionVaso)
                {
                    _renderAgua.material.SetFloat("Vector1_a8cc7360c9dd401a876115a77d6c0cd5", (nivel - 0.1f));
                }

            }
            else
            {
                if (myParticleSystem.isPlaying && !IsFinished) //Si se acaba el agua o se deja de tomar agua
                {
                    myParticleSystem.Stop();

                    if (nivel <= 0f)
                    {
                        IsFinished = true;
                        FindObjectOfType<DrinkAlcoholCinematica>().vasos++;
                        Debug.Log("TEST Aumenta cantidad de vaso");
                    }
                }
            }
        }
    }
}
