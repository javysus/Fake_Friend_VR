using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuisitoScript : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;
    [SerializeField] Transform[] Positions;
    [SerializeField] float ObjectSpeed;

    int NextPosIndex;
    Transform NextPos;
    private void OnTriggerEnter(Collider other)
    {
        myAnimationController.SetBool("baile", true);
    }
    // Start is called before the first frame update
    void Start()
    {
        myAnimationController.SetBool("caminar", true);
        NextPos = Positions[0];

    }

    void MoveGameObject()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        if (transform.position == NextPos.position)
        {
            NextPosIndex++;
            if (NextPosIndex >= Positions.Length)
            {
                myAnimationController.SetBool("caminar", false);
            }
            NextPos = Positions[NextPosIndex];
        }
        else
        {

            //transform.LookAt(NextPos.position);
            /*Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
            movementDirection.Normalize();

            if(movementDirection != Vector3.zero)
            {
                //Quaternion rotTarget = Quaternion.LookRotation(NextPos.position - transform.position);
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, ObjectSpeed * Time.deltaTime);

                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, ObjectSpeed * Time.deltaTime);
            }*/
            //transform.up = NextPos.position - transform.position;
            Quaternion rotTarget = Quaternion.LookRotation(NextPos.position - transform.position);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(98f, -25f, 120f), ObjectSpeed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, 50 * ObjectSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, NextPos.position, ObjectSpeed * Time.deltaTime);
            

        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveGameObject();

    }
}
