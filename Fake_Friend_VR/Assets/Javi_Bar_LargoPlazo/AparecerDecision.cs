using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerDecision : MonoBehaviour
{

    public GameObject panelHablar;

    public Transform Target;

    public HeredaXR cc;
    public float size = 0.01f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //animador.SetTrigger("HablarCollider");
            panelHablar.SetActive(true);
            //panelHablar.LeanScale(new Vector3(-size, size, size), 1f);
            //panelHablar.transform.LookAt(new Vector3(Target.position.x, panelHablar.transform.position.y, Target.position.z));

            cc.moveSpeed = 0f;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
