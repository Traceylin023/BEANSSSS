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

   [SerializerField] private int timeToShowUI = 1;
   [SerializerField] private GameObject showDoorLockedUI = null;

   [SerializerField] private KeyInventory _keyInventory = null;
 
   [SerializerField] private int waitTimer = 1;
   [SerializerField] private bool pauseInteraction = false;
   
   private void Awake ()
   {
      doorAnim = gameObject.GetComponent<Animator>();
   }

   private IEnumerator PauseDoorInteraction()
   {
      pauseInteraction = true;
      yield return new WaitForSeconds(waitTimer);
      pauseInteraction = false;
   }

   public void PlayAnimation()
      {
         if(_keyInventory.hasRedKey)
         {
            if(!doorOpen && !pauseInteraction)
            {
               doorAnim.Play(openAnimationName, 0, 0.0f);
               doorOpen = true;
               StartCoroutine(PauseDoorInteraction());
            }

            else if (doorOpen && !pauseInteraction)
            {
               doorAnim.Play(closeAnimationName, 0, 0.0f);
               doorOpen = false;
               StartCoroutine(PauseDoorInteraction());
            }
         }
         else
         {
            StartCoroutine(ShowDoorLocked());
         }
      }
   IEnumerator ShowDoorLocked()
   {
      showDoorLockedUI.SetActive(true);
      yield return new WaitForSeconds(timeToShowUI);
      showDoorLockedUI.SetActive(false);
   }

}
