using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offset;
    private Rigidbody rb;
    public float stoppingDistance = 0.1f;
    public float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {

        //transform.LookAt(objectToFollow);
        transform.position = Vector3.MoveTowards(transform.position, objectToFollow.transform.position, speed);
    }
    void FixedUpdate()
    {
        //transform.position = objectToFollow.position + offset;
        //rb.AddForce(objectToFollow.position * speed);
        //rb.MovePosition(transform.position + objectToFollow.position * speed * Time.deltaTime);
        /*Vector3 targetPosition = objectToFollow.position;
        Vector3 currentPotision = transform.position;

        float distance = Vector3.Distance(currentPotision, targetPosition);

        if(distance > stoppingDistance)
        {
            Vector3 directionOfTravel = targetPosition - currentPotision;
            directionOfTravel.Normalize();

            rb.MovePosition(currentPotision + (directionOfTravel * speed * Time.deltaTime));
        }*/

        //transform.position = Vector3.MoveTowards(transform.position, objectToFollow.transform.position, speed);
    }
}
