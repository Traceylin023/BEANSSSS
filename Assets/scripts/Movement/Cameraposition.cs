using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraposition : MonoBehaviour
{
    public Transform Placeholder;

    void Update()
    {
        // copies position of empty gameobject for camera
        transform.position = Placeholder.position;
    }
}
