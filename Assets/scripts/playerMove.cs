using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject player;
    public float speed = 32f;

    void Update()
    {
        float dt = Time.deltaTime;
        
        if(Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(-speed*dt, 0,0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(speed*dt, 0,0);
        }
        if(Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(0, 0, speed*dt);
        }
        if(Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(0, 0, -speed*dt);
        }
    }
}