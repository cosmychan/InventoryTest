using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventorymanager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryPrefab;

    public static Action<Item> OnAddItem;

    private void OnEnable()
    {
        //subscribe to event
        OnAddItem += AddItem;
    }

    private void OnDisable()
    {
        //unsubscribe to event to avoid nulls
        OnAddItem -= AddItem;
    }

    public void AddItem(Item item)
    {
        //used to find an empty slot in inventory
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            ItemInfoDisplay itemInSlot = slot.GetComponentInChildren<ItemInfoDisplay>();
            if (!itemInSlot) 
            {
                //if no item in slot - add item
                SpawnNewItem(item, slot);
                return;
            }
        }
    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        //spawn new item, the object prefab and the slot where to put it
        GameObject newItem = Instantiate(inventoryPrefab, slot.transform);
        ItemInfoDisplay inventoryItem = newItem.GetComponent<ItemInfoDisplay>(); //we get access to the ItemInfoDisplay script
        inventoryItem.InitialiseItem(item); //we assign the item that is needed to be setted
    }
}
