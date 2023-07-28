using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public GameObject player;
    public GameObject monster;
    public GameObject plane;

    public int[,] grid = new int[100,100];
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

        Debug.Log("path size: "+path.Count);
        Debug.Log("is it there: "+(monster.transform.position == player.transform.position));
        // If there are steps in the path, move the monster to the next step
        if (path.Count > 0)
        {
            Vector2 nextStep = path[0];
            Debug.Log("next step x: "+nextStep.x);
            Debug.Log("next step y: "+nextStep.y);
            monster.transform.Translate(nextStep.x, 0, nextStep.y);
            path.RemoveAt(0);
        }
    }

    private List<Vector2> updatePath()
    {
        List<Vector2> path = new List<Vector2>();

        float adjust = 0.5f;
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

        foreach (Vector2 direction in directions)
        {
            Vector3 newPosition = new Vector3(monster.transform.position.x + direction.x, monster.transform.position.y, monster.transform.position.z + direction.y);

            // Check if the new position is valid (i.e., not a wall and not outside the grid boundaries)
            Debug.Log("position: "+direction.x+" "+direction.y);
            if (IsValidPosition(newPosition))
            {
                Debug.Log("valid");
                // If the new position is closer to the player, add it to the path
                Debug.Log("monster: "+monster.transform.position.x+"  "+monster.transform.position.z);
                Debug.Log("player: "+player.transform.position.x+"  "+player.transform.position.z);
                Debug.Log("newPosition: "+newPosition.x+"  "+newPosition.z);
                if (closer(newPosition))
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
        int x = Mathf.RoundToInt(monster.transform.position.x+position.x);
        int z = Mathf.RoundToInt(monster.transform.position.z+position.z);
        if(x > -50 && x < 50 && z > -50 && z < 50){
            Debug.Log(x+"  "+z);
            return grid[x+50, z+50] == 0;
        } 
        return false;
    }

    private bool closer(Vector3 position)
    {
        return Vector3.Distance(position, player.transform.position) < Vector3.Distance(monster.transform.position, player.transform.position);
    }
}
