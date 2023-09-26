using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Spill_Restobar : MonoBehaviour
    {

        ParticleSystem myParticleSystem;
        public Renderer _renderAgua;
        public GameObject ObjAgua;
        public GameObject Particulas;
        public GameObject CamaraMareos;
        public GameObject DMRestobar;
        float nivel;
        float nivel_tomado;
        float ml = 0f; //Cantidad de agua tomada
        float ml_total = 255f; //Cantidad de agua del vaso
        public bool IsFinished = false;
        public int cantVasos = 0;
        float nivel_inicial = 0f;
        AudioSource _audioSource;

        float vector;

        // Start is called before the first frame update
        void Start()
        {
            myParticleSystem = Particulas.GetComponent<ParticleSystem>();
            vector = Particulas.GetComponent<ParticulasAguita>().vector;
            _renderAgua = ObjAgua.GetComponent<Renderer>();

            _audioSource = GetComponent<AudioSource>();
            _audioSource.playOnAwake = false;
        }

        //Consumir alcohol
        [ContextMenu("Consume")]
        public void Consume()
        {
            vector = Particulas.GetComponent<ParticulasAguita>().vector;
            bool IsFinished = Particulas.GetComponent<ParticulasAguita>().IsFinished;
            if (vector <= 140f && (!IsFinished))
            {
                nivel = _renderAgua.material.GetFloat("Vector1_a8cc7360c9dd401a876115a77d6c0cd5");
                if (nivel > nivel_inicial)
                {
                    nivel_inicial = _renderAgua.material.GetFloat("Vector1_a8cc7360c9dd401a876115a77d6c0cd5");
                }

                if (!_audioSource.isPlaying)
                {
                    _audioSource.Play();
                }//
            }
        }



        // Update is called once per frame
        void FixedUpdate()
        {
            nivel = _renderAgua.material.GetFloat("Vector1_a8cc7360c9dd401a876115a77d6c0cd5");
            Debug.Log("Test nivel de agua " + nivel);
            if ((Vector3.Angle(Vector3.down, transform.up) <= 140f) && (nivel > 0f))
            {
                if (!myParticleSystem.isPlaying)
                {
                    myParticleSystem.Play();
                }

                //_renderAgua.material.SetFloat("Vector1_a8cc7360c9dd401a876115a77d6c0cd5", (nivel - 0.002f));

            }
            else if (nivel < 0f && !IsFinished)
            {
                if (myParticleSystem.isPlaying) //Si se acaba el agua o se deja de tomar agua
                {
                    myParticleSystem.Stop();
                    IsFinished = true;
                    //Actualizar en la base de datos el valor de ml del usuario + el ml tomado ahora

                    Debug.Log("Se termina el vasito");
                    cantVasos++;
                    if (cantVasos == 1)
                    {
                        Debug.Log("Primeros mareos");
                        CamaraMareos.GetComponent<ShakeableTransform>().enabled = true;
                        //Cotinuar dialogo
                       
                    }

                }
            }
            else
            {
                if (myParticleSystem.isPlaying) //Si se acaba el agua o se deja de tomar agua
                {
                    myParticleSystem.Stop();
                    IsFinished = true;
                    //Actualizar en la base de datos el valor de ml del usuario + el ml tomado ahora
                }
            }
        }
    }