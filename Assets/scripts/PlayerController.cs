using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text noteText; // Reference to the UI Text component
    private bool isReadingNote = false;
    private Camera mainCamera;
    private InteractableObject lastInteractable;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for left mouse button click
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                InteractableObject interactableObject = hit.collider.GetComponent<InteractableObject>();
                if (interactableObject != null)
                {
                    if (interactableObject == lastInteractable)
                    {
                        // The same object was clicked again, interact with it
                        interactableObject.Interact();
                    }
                    else
                    {
                        // A new object was clicked, reset the previous one and interact with the new one
                        if (lastInteractable != null)
                        {
                            lastInteractable.ResetInteractable();
                        }
                        interactableObject.Interact();
                        lastInteractable = interactableObject;
                    }
                }
                else if (lastInteractable != null)
                {
                    // Clicked on something else, reset the previous interactable
                    lastInteractable.ResetInteractable();
                    lastInteractable = null;
                }
            }
            else if (lastInteractable != null)
            {
                // Clicked on nothing, reset the previous interactable
                lastInteractable.ResetInteractable();
                lastInteractable = null;
            }
        }

        // Add your other player movement and interactions here
        // ...
    }

    public void ShowNoteContent(string content)
    {
        isReadingNote = true;
        noteText.gameObject.SetActive(true);
        noteText.text = content;
    }

    public void HideNoteContent()
    {
        isReadingNote = false;
        noteText.gameObject.SetActive(false);
        noteText.text = "";
    }
}
