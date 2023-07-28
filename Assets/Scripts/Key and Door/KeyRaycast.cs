using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyRaycast : MonoBehaviour
    {
        [SerializerField] private int rayLength = 5;
        [SerializerField] private LayerMask layerMaskInteract;
        [SerializerField] private string excluseLayerName = null;
        
        private KeyItemController raycastedObject;
        [SerializerField] private KeyCode openDoorKey = KeyCode.Mouse0;

         [SerializerField] private Image crosshair = null;
         private bool isCrosshairActive;
         private bool doOnce;

         private string interactableTag = "InteractiveObject";

         private void Update()
         {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(excluseLayerName) | layerMaskInteract.value;

            if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
            {
                if (hit.collider.CompareTag(interactableTag))
                {
                    if (!doOnce)
                    {
                        raycastedObject = hit.collider.gameObject.GetComponent<KeyItemController>();
                    }

                    isCrosshairActive = true;
                    doOnce = true;

                    if (Input.GetKeyDown(openDoorKey))
                    {
                        raycastedObject.ObjectInteraction();
                    }
                }
            }
            else;
            {
                if(isCrosshairActive)
                {
                    CrosshairChange(false);
                    doOnce = false;
                }
            }
         }

         void CrosshairChange(bool on)
         {
            if (on && !doOnce)
            {
                crosshair.color = Color.red;
            }
            else
            {
                crosshair.color = Color.white;
                isCrosshairActive = false;
            }
         }

     }
}