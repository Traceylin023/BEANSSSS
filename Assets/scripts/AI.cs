using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public GameObject player;
    public GameObject monster;

    public int[,] grid = new int[20,20];
    public List<Vector2> path = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        //0 == space
        //1 == wall
        //2 == path
        Debug.ClearDeveloperConsole();

        
        for(int i=0;i<grid.GetLength(0);i++){
            for(int j=0;j<grid.GetLength(1);j++){
                grid[i, j]=0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Get the updated path
        path = updatePath();

        Debug.Log(path.Count);
        Debug.Log(monster.transform.position == player.transform.position);
        // If there are steps in the path, move the monster to the next step
        if (path.Count > 0)
        {
            Debug.Log("testing");
            Vector2 nextStep = path[0];
            Debug.Log("x: "+nextStep.x);
            Debug.Log("y: "+nextStep.y);
            monster.transform.Translate(nextStep.x, 0, nextStep.y);
            path.RemoveAt(0);
        }
    }

    private List<Vector2> updatePath()
    {
        List<Vector2> path = new List<Vector2>();

        float adjust = 0.1f;
        Vector2[] directions = new Vector2[]
        {
            new Vector2(0f, 1f),  // Up
            new Vector2(1f, 1f),  // Up-Right
            new Vector2(1f, 0f),  // Right
            new Vector2(1f, -1f), // Down-Right
            new Vector2(0f, -1f), // Down
            new Vector2(-1f, -1f),// Down-Left
            new Vector2(-1f, 0f), // Left
            new Vector2(-1f, 1f)  // Up-Left
        };

        foreach (Vector2 direction in directions)
        {
            Vector3 newPosition = new Vector3(monster.transform.position.x + direction.x, monster.transform.position.y, monster.transform.position.z + direction.y);

            // Check if the new position is valid (i.e., not a wall and not outside the grid boundaries)
            if (IsValidPosition(newPosition))
            {
                Debug.Log("found position");
                float distance = Vector3.Distance(newPosition, player.transform.position);
                // If the new position is closer to the player, add it to the path
                Debug.Log("monster: "+monster.transform.position.x+"  "+monster.transform.position.z);
                Debug.Log("player: "+player.transform.position.x+"  "+player.transform.position.z);
                Debug.Log("newPosition: "+newPosition.x+"  "+newPosition.z);
                if (closer(newPosition, distance))
                {
                    Debug.Log("add position");
                    path.Add(direction);
                }
            }
        }

        return path;
    }

    private bool IsValidPosition(Vector3 position)
    {
        int x = Mathf.RoundToInt(position.x);
        int z = Mathf.RoundToInt(position.z);
        if (x < 0 || x >= grid.GetLength(0) || z < 0 || z >= grid.GetLength(1))
            return false;
        return grid[x, z] == 0;
    }

    private bool closer(Vector3 position, float distance)
    {
        return Vector3.Distance(position, player.transform.position) < distance;
    }
}
