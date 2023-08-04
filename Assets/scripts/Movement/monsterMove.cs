using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterMove : MonoBehaviour
{

    public GameObject player;
    public GameObject monster;

    public List<Vector2> path = new List<Vector2>();

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

        monster.transform.position = new Vector3(157.0f, 2.0f, 138.0f);
        monster.transform.LookAt(player.transform.position);
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
        monster.transform.LookAt(player.transform.position);

        Debug.Log("monster position: "+monster.transform.position.x+"    "+monster.transform.position.z);
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
    }

    private Vector2 updatePath()
    {
        int adjust = 1;
        List<Vector2> directions = new List<Vector2>()

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

        Vector2 nextDirection = new Vector2(monster.transform.position.x, monster.transform.position.z);

        foreach (Vector2 direction in directions)
        {

            // Get the desired position you want to move to
            Vector3 desiredPosition = new Vector3(monster.transform.position.x+direction.x, monster.transform.position.y, monster.transform.position.z+direction.y);

            // Check if there are any colliders overlapping with a sphere at the desired position
            Collider[] colliders = Physics.OverlapSphere(desiredPosition, 0.1f);

            bool canMove = true;

            // Loop through the colliders found
            
            foreach (Collider collider in colliders)
            {
                // Check if any of the colliders have a Rigidbody attached
                if (collider.GetComponent<Rigidbody>() != null && !collider.CompareTag("monster"))
                {
                    // If a Rigidbody is found, the object can't move to the desired position
                    canMove = false;
                    break;
                }
            }

            //Debug.Log("can move: "+canMove);

            // If canMove is true, the GameObject can move to the desired position
            if (canMove)
            {
                if (closer(direction, nextDirection)){
                    nextDirection=direction;
                }
            }
        }

        return nextDirection;
    }

    private bool closer(Vector2 position1, Vector2 position2)
    {
        return Vector3.Distance(new Vector3(monster.transform.position.x + position1.x, monster.transform.position.y, monster.transform.position.z + position1.y), player.transform.position) < Vector3.Distance(new Vector3(monster.transform.position.x + position2.x, monster.transform.position.y, monster.transform.position.z + position2.y), player.transform.position);
    }

    // private List<Vector2> updatePath() {

    //     // Lets determine our path
    //     List<Vector2> best_path = new List<Vector2>();
    //     Vector2 goal = new Vector2(player.transform.position.x, player.transform.position.z);

    //     List<List<Vector2>> horizon = new List<List<Vector2>>();
    //     List<List<Vector2>> horizonPosition = new List<List<Vector2>>();
    //     Vector2 startPosition = new Vector2(monster.transform.position.x, monster.transform.position.z);

    //     Vector2 start = new Vector2(0.0f,0.0f);

    //     List<Vector2> start_path = new List<Vector2>();
    //     List<Vector2> start_pathPosition = new List<Vector2>();
    //     start_pathPosition.Add(startPosition);
    //     start_path.Add(start);
    //     HashSet<Vector2> visited = new HashSet<Vector2>();
    //     horizon.Add(start_path);
    //     horizonPosition.Add(start_pathPosition);
    //     bool found = false;

    //     for(int i=0;i<horizon.Count;i++){
   
    //         List<Vector2> current_path = horizon[0];
    //         List<Vector2> current_pathPosition = horizonPosition[0];
    //         horizon.RemoveAt(0);
    //         horizonPosition.RemoveAt(0);
    //         Vector2 current_nodePosition = current_pathPosition[current_pathPosition.Count-1];

    //         visited.Add(current_nodePosition);
    //         if (Vector2.Distance(current_nodePosition, goal)<.1) {
    //             best_path = current_path;
    //             break;
    //         }

    //         Debug.Log("current path size: "+current_path.Count);
    //         Debug.Log("first  position: "+current_path[0]);
    //         Debug.Log("current position: "+current_nodePosition);

    //         List<Vector2> potential_neighbors = addDirection(current_nodePosition);

    //         Debug.Log("neighbor size: "+potential_neighbors.Count);
  
    //         // check if coordinates are INSIDE of the grid (not negative or anything)
    //         // check if the coordinates are in the visited set
    //         // check if the transition from current_node to this cell is valid
    //         for (int i = 0; i < potential_neighbors.Count; i++) {
    //             Vector2 candidate_node = potential_neighbors[i];
    //             Vector2 candidate_nodePosition = new Vector2(current_nodePosition.x+potential_neighbors[i].x, current_nodePosition.y+potential_neighbors[i].y);
    //             Debug.Log("visited size: "+visited.Count);  
    //             if (!visited.Contains(candidate_nodePosition)) {
    //                 List<Vector2> new_path_with_added_node = new List<Vector2>();
    //                 new_path_with_added_node.AddRange(current_path);
    //                 new_path_with_added_node.Add(candidate_node);
    //                 horizon.Add(new_path_with_added_node);

    //                 List<Vector2> new_path_with_added_nodePosition = new List<Vector2>();
    //                 new_path_with_added_nodePosition.AddRange(current_pathPosition);
    //                 new_path_with_added_nodePosition.Add(candidate_nodePosition);
    //                 horizonPosition.Add(new_path_with_added_nodePosition);

    //                 Debug.Log("working dir: "+candidate_node.x+"   "+candidate_node.y);
    //                 Debug.Log("next position: "+candidate_nodePosition.x+"   "+candidate_nodePosition.y);
    //             }
    //         }
    //     }

    //     if (best_path.Count == 0) {
    //     Debug.Log("Could not find path");
    //     }else{
    //         Debug.Log("first position: "+best_path[0]);
    //     }

    //     return best_path;
    // }

}