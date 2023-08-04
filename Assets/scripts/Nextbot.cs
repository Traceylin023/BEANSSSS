
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nextbot : MonoBehaviour
{

   public GameObject player;
   public GameObject monster;

   public ButtonEndUI gameUI;

   public float speed;

//    void Start()
//     {
//         StartCoroutine(SleepCoroutine());
//     }

//     IEnumerator SleepCoroutine()
//     {
//         // Disable the Rigidbody to prevent the GameObject from moving
//         Rigidbody rb = GetComponent<Rigidbody>();
//         if (rb != null)
//             rb.isKinematic = true;

//         // Optionally disable other movement-related components like character controllers, etc.

//         // Wait for the specified duration
//         yield return new WaitForSeconds(20f);

//         // Re-enable the Rigidbody to allow movement after the sleep period
//         if (rb != null)
//             rb.isKinematic = false;

//         // Optionally re-enable other movement-related components if they were disabled earlier.
//     }

    float timer = 0;
    bool timerReached = false;

    void Update()
    {
        if (!timerReached)
            timer += Time.deltaTime;

        if (!timerReached && timer > 20)
        {
            transform.LookAt(player.transform.position);
            transform.Translate(0,0,speed*Time.deltaTime);
            transform.Rotate(90, 0, 0);
        }

        float distance = Vector3.Distance(monster.transform.position, player.transform.position);

        if(distance < 0.2f){
            Destroy(player);
            Destroy(monster);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gameUI.NewGameButton();
        }
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