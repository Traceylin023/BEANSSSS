using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blindCharacter : MonoBehaviour
{

    public Transform player; // The other character to chase
    public float movementSpeed = 5f;
    public float detectionRadius = 10f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the target is within the detection radius
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget <= detectionRadius)
        {
            // Chase the target
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            rb.MovePosition(transform.position + directionToTarget * movementSpeed * Time.deltaTime);

            // Rotate towards the target
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget, Vector3.up);
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, 180f * Time.deltaTime));
        }
    }
}

