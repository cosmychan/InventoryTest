using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    // via this script we could change the text of the Pick Up panel, but for now we can leave it like this
    // otherwise via another action in the UI Manager for text prompt to change would be added

    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt; //reference the text to the prompt

    public Item item; //reference de item data

    public bool Interact(Interactor interactor)
    {
        bool result = Inventorymanager.OnAddItem(item); //add the item to the inventory. Return true if added and false if not
        if (result)
        {
            UIManager.OnInteractionTextToggled?.Invoke(false); //turn on the interaction text panel
            Destroy(gameObject);
            return true;
        }
        else
        {
            return false;
        }
        
        
    }
}
