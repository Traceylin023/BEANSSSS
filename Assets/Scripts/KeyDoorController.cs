using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoorContoller : MonoBehaviour
{
   private Animator doorAnim;
   private bool doorOpen = false; 

   [Header("Animation Names")]
   [SerializerField] private string openAnimationName = "DoorOpen";
   [SerializerField] private string closeAnimationName = "DoorClose";

}
