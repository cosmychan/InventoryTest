using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//we use this class for interaction - pick up objects

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius,
            _colliders, _interactableMask);

        if (_numFound > 0)
        {
            var interactable = _colliders[0].GetComponent<IInteractable>();

            UIManager.OnInteractionTextToggled?.Invoke(true); //turn on the interaction text panel

            //if there is something to interact with and the player pressed the button for it - interact
            if (interactable != null && Input.GetButtonDown("Submit"))
            {
                interactable.Interact(this);
            }
        }
        else
        {
            UIManager.OnInteractionTextToggled?.Invoke(false); //turn off the interaction text panel
        }
    }

    private void OnDrawGizmos()
    {
        //for visual understanding of the interaction point
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);

    }
}
