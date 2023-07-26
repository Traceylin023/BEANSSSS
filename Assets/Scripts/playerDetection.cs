using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
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
        // Check if the player is within the detection radius
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRadius)
        {
            // Chase the player
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            rb.MovePosition(transform.position + directionToPlayer * movementSpeed * Time.deltaTime);

            // Rotate towards the player
            Quaternion playerRotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, playerRotation, 180f * Time.deltaTime));
        }
    }
}

