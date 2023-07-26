using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool isNote = false;
    public string noteContent = "This is a sample note.";

    private bool isPickedUp = false;
    private Transform originalParent;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Interact()
    {
        if (!isPickedUp)
        {
            // Pick up the object
            isPickedUp = true;
            originalParent = transform.parent;
            rb.isKinematic = true;
            transform.SetParent(Camera.main.transform); // Attach the object to the camera to follow the player's view
            transform.localPosition = new Vector3(0.2f, 0.2f, 1f); // Adjust position to be in front of the camera
            transform.localRotation = Quaternion.identity; // Reset rotation
        }
        else
        {
            // Use the object (e.g., read the note)
            if (isNote)
            {
                // Implement note reading functionality here
                Debug.Log("Note Content: " + noteContent);
            }

            // Drop the object
            isPickedUp = false;
            rb.isKinematic = false;
            transform.SetParent(originalParent);
        }
    }

    public void ResetInteractable()
    {
        if (isNote && isPickedUp)
        {
            // Drop the note when clicking on something else
            isPickedUp = false;
            rb.isKinematic = false;
            transform.SetParent(originalParent);

            // Hide the note on the screen
            //playerController.HideNoteContent();
        }
    }
}

