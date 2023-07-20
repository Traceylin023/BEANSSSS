using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraposition : MonoBehaviour
{
    public Transform cameraPosition;

    void Update()
    {
        // copies position of empty gameobject for camera
        transform.position = cameraPosition.position;
    }
}
