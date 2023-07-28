using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public GameObject player;
    public float speed = 16f;

    void Update()
    {
        float dt = Time.deltaTime;

        Debug.Log("PLAYER: "+(player.transform.position.x)+"  "+player.transform.position.z);
        
        if(Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(-speed*dt, 0,0);
            player.transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, -50, 50), 1, Mathf.Clamp(player.transform.position.z, -50, 50));

            // if(player.transform.position.x-speed*dt > -50 && player.transform.position.x-speed*dt < 50)
            // {
            //     Debug.Log("KEY A");
            //     Debug.Log("positionX: "+(player.transform.position.x-speed*dt));
            //     Debug.Log("speed*dt: "+(player.transform.position.x)+"   "+(speed*dt));
            //     player.transform.Translate(-speed*dt, 0,0);
            //     Debug.Log("PLAYER AFTER: "+(player.transform.position.x)+"  "+player.transform.position.z);
            // }
        }
        if(Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(speed*dt, 0,0);
            player.transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, -50, 50), 1, Mathf.Clamp(player.transform.position.z, -50, 50));

            // if(player.transform.position.x+speed*dt > -50 && player.transform.position.x+speed*dt < 50)
            // {
            //     Debug.Log("KEY D");
            //     Debug.Log("positionX: "+(player.transform.position.x+speed*dt));
            //     Debug.Log("speed*dt: "+(player.transform.position.x)+"   "+(speed*dt)+"  "+(player.transform.position.x+speed*dt));
            //     player.transform.Translate(speed*dt, 0,0);
            //     Debug.Log("PLAYER AFTER: "+(player.transform.position.x)+"  "+player.transform.position.z);
            // }
        }
        if(Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(0, 0, speed*dt);
            player.transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, -50, 50), 1, Mathf.Clamp(player.transform.position.z, -50, 50));

            // if(player.transform.position.z+speed*dt > -50 && player.transform.position.z+speed*dt < 50)
            // {
            //     Debug.Log("KEY W");
            //     Debug.Log("positionY: "+(player.transform.position.z+speed*dt));
            //     Debug.Log("speed*dt: "+(player.transform.position.z)+"   "+(speed*dt));
            //     player.transform.Translate(0, 0,speed*dt);
            //     Debug.Log("PLAYER AFTER: "+(player.transform.position.x)+"  "+player.transform.position.z);
            // }
        }
        if(Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(0, 0, -speed*dt);
            player.transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, -50, 50), 1, Mathf.Clamp(player.transform.position.z, -50, 50));

            // if(player.transform.position.z-speed*dt > -50 && player.transform.position.z-speed*dt < 50)
            // {
            //     Debug.Log("KEY S");
            //     Debug.Log("positionY: "+(player.transform.position.z-speed*dt));
            //     Debug.Log("speed*dt: "+(player.transform.position.x)+"   "+(speed*dt));
            //     player.transform.Translate(-speed*dt, 0,0);
            //     Debug.Log("PLAYER AFTER: "+(player.transform.position.x)+"  "+player.transform.position.z);
            // }
        }
    }
}