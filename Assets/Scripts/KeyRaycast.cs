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
        // private KeyItemController raycatedObject;

     }
}