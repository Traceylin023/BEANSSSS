using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterMove : MonoBehaviour
{

    public GameObject player;
    public GameObject monster;

    [Header ("Movement")]
    public float moveSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatisground;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

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
     
       MyInput();
       
       if (grounded)
           rb.drag = groundDrag;
       else 
           rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = updatePath().x;
        verticalInput = updatePath().y;
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        orientation.position = new Vector3(Mathf.Clamp(orientation.position.x, -50, 50), 1, Mathf.Clamp(orientation.position.z, -50, 50));
    }

    private Vector2 updatePath()
    {
        int adjust = 1;
        Vector2[] directions = new Vector2[]
        {
            new Vector2(0f, adjust),  // Up
            new Vector2(adjust, adjust),  // Up-Right
            new Vector2(adjust, 0f),  // Rightadjust
            new Vector2(adjust, -adjust), // Down-Right
            new Vector2(0f, -adjust), // Down
            new Vector2(-adjust, -adjust),// Down-Left
            new Vector2(-adjust, 0f), // Left
            new Vector2(-adjust, adjust)  // Up-Left
        };

        Vector2 nextDirection = directions[0];

        foreach (Vector2 direction in directions)
        {
            if (closer(direction, nextDirection))
            {
                nextDirection=direction;
            }
        }

        return nextDirection;
    }


    private bool closer(Vector2 position1, Vector2 position2)
    {
        return Vector3.Distance(new Vector3(monster.transform.position.x + position1.x, monster.transform.position.y, monster.transform.position.z + position1.y), player.transform.position) < Vector3.Distance(new Vector3(monster.transform.position.x + position2.x, monster.transform.position.y, monster.transform.position.z + position2.y), player.transform.position);
    }
}