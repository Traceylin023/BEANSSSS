
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nextbot : MonoBehaviour
{
   public GameObject player;

    [Header ("Movement")]
    public float moveSpeed;
    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatisground;
    bool grounded;

    Vector3 moveDirection;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
       grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 2f, whatisground);
       rb.drag = groundDrag;
       transform.LookAt(player.transform.position);
       transform.Rotate(90, 0, 0);
       MovePlayer();
    }
    
    private void MovePlayer()
    {
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}