using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Item item; //reference de item data

    public void Interact()
    {
        Inventorymanager.OnAddItem(item); //add the item to the inventory
        Destroy(gameObject);
    }
}
