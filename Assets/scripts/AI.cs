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
        path = updatePath();
        Debug.Log("x: "+path[0].x);
        Debug.Log("y: "+path[0].y);
        monster.transform.Translate(path[0].x, 0, path[0].y);
        path.RemoveAt(0);
    }

    private List<Vector2> updatePath()
    {
        List<Vector2> path = new List<Vector2>();

        while(player.transform.position.x != monster.transform.position.x && player.transform.position.z != monster.transform.position.z){
            Vector2 x = new Vector2(0f,0f);
            if(player.transform.position.x > monster.transform.position.x){
                x.X++;
            }
            if(player.transform.position.z > monster.transform.position.z){
                x.Y++;
            }
            if(
            path.Add(x);
        }

        return path;
    }

    private bool IsValidPosition(Vector2 v)
    {
        return monster.transform.position.x+v.X > grid. && b >= 0 && b < grid.GetLength(1);
    }
}