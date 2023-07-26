using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotate : MonoBehaviour
{
    public float Xaxis = 1600f;
    public float Yaxis = 1600f;

    public Transform orientation;

    public float xrotation = 0f;
    public float yrotation = 0f;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * Xaxis;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * Yaxis;

        yrotation = yrotation + mouseX;
        xrotation = xrotation - mouseY;

        xrotation = Mathf.Clamp(xrotation, -90f, 90f);

        // rotation of the player and the camera
        transform.rotation = Quaternion.Euler(xrotation, yrotation, 0);
        orientation.rotation = Quaternion.Euler(0, yrotation, 0);
    }  
}