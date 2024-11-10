using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string InteractionPrompt { get; } //to get the text for the prompt
    public bool Interact(Interactor interactor); //the method for intheraction
}
