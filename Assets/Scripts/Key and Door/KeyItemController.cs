using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
        {
            [SerializerField] private bool redDoor = false; 
            [SerializerField] private bool redKey = false; 
            
            [SerializerField] private KeyInventory _keyInventory = null;

            private KeyDoorController doorObject;

            private void Start()
            {
                if (redDoor)
                {
                    doorObject = GetComponent<KeyDoorController>();
                }
            }

             private void ObjectInteraction()
            {
                if (redDoor)
                {
                    doorObject.PlayAnimation();
                }
                else if(redKey)
                {
                    _keyInventory.hasRedKey = true;
                    gameObject.SetActive(false);
                }
            }
        }
}
