using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.Characters.FirstPerson;


public class ReadNotes : MonoBehaviour
{
    public GameObject player;
    public GameObject noteUI;

    public AudioSource pickUpSound;

    public bool inReach;



    void Start()
    {
        noteUI.SetActive(false);
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
        if(inReach && Input.GetButtonDown("Interact"))
        {
            noteUI.SetActive(true);
            pickUpSound.Play();
            Cursor.visible = true;

        }
    }

    public void ExitButton()
    {

        noteUI.SetActive(false);
        Cursor.visible = false;
    }
}

