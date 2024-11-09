using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//we use this class for interaction - pick up objects

public class Interactor : MonoBehaviour
{
    [SerializeField] private float interactionRange = 3f; // Range within which the player can interact
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        DetectInteractable(); //check for interaction
    }

    private void DetectInteractable()
    {
        // ray from the camera to detect objects within interaction range
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            // check if the object has an Interactable component
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                UIManager.OnInteractionTextToggled?.Invoke(true); //turn on the interaction text panel

                // we check if player presses the interaction key
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact(); // interaction
                    UIManager.OnInteractionTextToggled?.Invoke(false); // hide the interaction text panel
                }
                return;
            }
        }
    }
}
