using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform cameraPosition;

    void Update()
    {
        // copies position of empty gameobject for camera
        transform.position = cameraPosition.position;
    }
}
