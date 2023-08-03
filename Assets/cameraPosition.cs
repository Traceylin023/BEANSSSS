using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPosition : MonoBehaviour
{
    public GameObject player;
    public GameObject camera;

    void Update()
    {
        // copies position of empty gameobject for camera
        camera.transform.position = player.transform.position;
    }
}
