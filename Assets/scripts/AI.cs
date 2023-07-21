using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public GameObject player;
    public GameObject monster;

    public bool[,] grid;
    public List<Vector2Int> path = new List<Vector2Int>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        path = updatePath();
        monster.transform.position = new Vector3(path[0].x, 0, path[0].y);
        path.RemoveAt(0);

    }

    // private List<Vector2Int> updatePath()
    // {

    //     // Implement the A* algorithm here to find the shortest path between the start and target positions.
    //     // Use the grid and its nodes to navigate the path.

    //     // For this basic example, we'll return a straight path from start to end.
    //     // You need to implement the actual A* algorithm based on your grid and requirements.
    //     // In a real implementation, this would be replaced with the A* algorithm logic.

    //     //0==brick, 1==space, 2==path;

    //     path.Add(new Vector2Int(monster.transform.position.x, monster.transform.position.z));
    //     Vector2Int current = start;

    //     Vector2Int end = new Vector2Int(player.transform.position.x, player.transform.position.z);

    //     while (current != end)
    //     {
    //         Vector2Int next = new Vector2Int(current.x + Mathf.Sign(end.x - current.x), current.y + Mathf.Sign(end.y - current.y));

    //         // Check if the next cell is within the grid bounds and is not blocked.
    //         if (next.x == 0 && next.x < gridSizeX && next.y >= 0 && next.y < gridSizeY && grid[next.x, next.y] == 1)
    //         {
    //             current = next;
    //             path.Add(current);
    //         }
    //     }

    //     return path;
    // }

    private List<Vector2Int> updatePath()
    {

        Vector2Int start = new Vector2Int((int)monster.transform.position.x, (int)monster.transform.position.z);
        Vector2Int end = new Vector2Int((int)player.transform.position.x, (int)player.transform.position.z);

        Queue<Vector2Int> queue = new Queue<Vector2Int>();
        Dictionary<Vector2Int, Vector2Int> parentMap = new Dictionary<Vector2Int, Vector2Int>();

        queue.Enqueue(start);
        parentMap[start] = start;

        while (queue.Count > 0)
        {
            Vector2Int current = queue.Dequeue();

            if (current == end)
            {
                // Reached the destination, reconstruct the path from parentMap.
                while (current != start)
                {
                    path.Add(current);
                    current = parentMap[current];
                }

                path.Reverse(); // Reverse the list to get the correct order of positions.
                path.Add(start);
                break;
            }

            // Get neighbors of the current cell.
            Vector2Int[] neighbors =
            {
                new Vector2Int(current.x + 1, current.y),
                new Vector2Int(current.x - 1, current.y),
                new Vector2Int(current.x, current.y + 1),
                new Vector2Int(current.x, current.y - 1)
            };

            foreach (Vector2Int neighbor in neighbors)
            {
                if (IsValidPosition(neighbor) && grid[neighbor.x, neighbor.y] && !parentMap.ContainsKey(neighbor))
                {
                    queue.Enqueue(neighbor);
                    parentMap[neighbor] = current;
                }
            }
        }

        return path;
    }

    private bool IsValidPosition(Vector2Int position)
    {
        return position.x >= 0 && position.x < grid.GetL && position.y >= 0 && position.y < gridSizeY;
    }
}
