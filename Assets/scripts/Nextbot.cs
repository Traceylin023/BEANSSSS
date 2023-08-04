
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nextbot : MonoBehaviour
{

   public GameObject player;

   public float speed;

    void Update()
    {
        transform.LookAt(player.transform.position);
        transform.Translate(0,0,speed*Time.deltaTime);
        transform.Rotate(90, 0, 0);
    }


    void OnCollisionStay(Collision Obj) {
        if(Obj.gameObject.name == "Player"){
                speed = 0f;
         }
         else{
             speed = 10f;
         }
    }
}