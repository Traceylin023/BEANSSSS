using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKeyPad : MonoBehaviour
{
    public GameObject keypadOB;

    public bool inReach;


    void Start()
    {
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
        }
    }




    void Update()
    {
        if(Input.GetButtonDown("Interact") && inReach)
        {
            keypadOB.SetActive(true);
        }
        

    }
}