using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public GameObject player;
    public GameObject monster;
    public static float adjust = 5f;

    public int[,] grid = new int[(int)(1000),(int)(1000)];
    public List<Vector2> path = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        //0 == space
        //1 == wall
        //2 == path
        Debug.ClearDeveloperConsole();

        //Debug.Log(grid.GetLength(0)+"   "+grid.GetLength(1));

        
        for(int i=0;i<grid.GetLength(0);i++){
            for(int j=0;j<grid.GetLength(1);j++){
                grid[i, j]=0;
            }
        }

        player.transform.position = new Vector3(-50,1,-50);
        monster.transform.position = new Vector3(0,2,0);
    }

    // Update is called once per frame
    void Update()
    {

        float dt = Time.deltaTime;
        // Get the updated path
        path = updatePath();

        //Debug.Log("path size: "+path.Count);
        //Debug.Log("is it there: "+(monster.transform.position == player.transform.position));
        // If there are steps in the path, move the monster to the next step
        if (path.Count > 0 && Vector3.Distance(monster.transform.position, player.transform.position)>0.1)
        {
            Vector2 nextStep = path[0];
            //Debug.Log("next step x: "+nextStep.x);
            //Debug.Log("next step y: "+nextStep.y);
            monster.transform.Translate(nextStep.x*dt, 0, nextStep.y*dt);
            path.RemoveAt(0);
        }
    }

    private List<Vector2> updatePath()
    {
        List<Vector2> path = new List<Vector2>();

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

            // Check if the new position is valid (i.e., not a wall and not outside the grid boundaries)
            //Debug.Log("position: "+direction.x+" "+direction.y);
            //Debug.Log("monster: "+monster.transform.position.x+"  "+monster.transform.position.z);
            //Debug.Log("player: "+player.transform.position.x+"  "+player.transform.position.z);
            if (IsValidPosition(direction))
            {
                //Debug.Log("valid");
                // If the new position is closer to the player, add it to the path
                if (closer(direction, nextDirection))
                {
                    //Debug.Log("change nextDirection");
                    nextDirection=direction;
                }
            }
        }

        //Debug.Log("next direction is: "+nextDirection.x+"  "+nextDirection.y);
        path.Add(nextDirection);

        return path;
    }

    private bool IsValidPosition(Vector2 direction)
    {
        int x = Mathf.RoundToInt(10*(monster.transform.position.x+direction.x));
        int z = Mathf.RoundToInt(10*(monster.transform.position.z+direction.y));
        if(x > -500 && x < 500 && z > -500 && z < 500){
            return grid[x+500, z+500] == 0;
        } 
        return false;
    }

    private bool closer(Vector2 position1, Vector2 position2)
    {
        return Vector3.Distance(new Vector3(monster.transform.position.x + position1.x, monster.transform.position.y, monster.transform.position.z + position1.y), player.transform.position) < Vector3.Distance(new Vector3(monster.transform.position.x + position2.x, monster.transform.position.y, monster.transform.position.z + position2.y), player.transform.position);
    }
}
