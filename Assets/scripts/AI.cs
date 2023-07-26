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
            Vector2 x;
            Vector2 a = new Vector2(0f,1f);
            Vector2 b = new Vector2(1f,1f);
            Vector2 c = new Vector2(1f,0f);
            Vector2 d = new Vector2(0f,-1f);
            Vector2 e = new Vector2(-1f,-1f);
            Vector2 f = new Vector2(-1f,0f);
            Vector2 g = new Vector2(1f,-1f);
            Vector2 h = new Vector2(-1f,1f);
            float distance = Vector3.Distance(monster.transform.position, player.transform.position);
            if(IsValidPosition(a) && closer(a, d)){
                x=a;
            }
            if(IsValidPosition(b) && closer(b, d)){
                x=b;
            }
            if(IsValidPosition(c) && closer(c, d)){
                x=c;
            }
            if(IsValidPosition(d) && closer(d, d)){
                x=d;
            }
            if(IsValidPosition(e) && closer(e, d)){
                x=e;
            }
            if(IsValidPosition(f) && closer(f, d)){
                x=f;
            }
            if(IsValidPosition(g) && closer(g, d)){
                x=g;
            }
            if(IsValidPosition(h) && closer(h, d)){
                x=h;
            }
            path.Add(x);
        }

        return path;
    }

    private bool IsValidPosition(Vector2 v)
    {
        return grid[monster.transform.position.x+v.X, monster.transform.position.z+v.Y] == 0;
    }

    private bool closer(Vector2 v, float d)
    {
        return Vector3.Distance(new Vector3(monster.transform.position.x+v.X, monster.transform.position.y, monster.transform.position.z+v.Y), player.transform.position) < d;
    }
}
