using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventorymanager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryPrefab;
    public bool isAdded;
    public int selectedSlot = -1;

    public static Func<Item, bool> OnAddItem;
    public static Action<Item> OnMinusItem;

    private void OnEnable()
    {
        //subscribe to event
        OnAddItem += AddItem;
        OnMinusItem += MinusItem;
    }

    private void OnDisable()
    {
        //unsubscribe to event to avoid nulls
        OnAddItem -= AddItem;
        OnMinusItem -= MinusItem;
    }

    public bool AddItem(Item item)
    {
        //used to find a slot with the same item type and count lower then the maximum number
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            ItemInfoDisplay itemInSlot = slot.GetComponentInChildren<ItemInfoDisplay>();
            if (itemInSlot != null && 
                itemInSlot.item == item 
                && itemInSlot.item.isStackable 
                && itemInSlot.itemCount < itemInSlot.item.maxStack)
            {
                //if item already in slot - stack
                itemInSlot.itemCount++;
                itemInSlot.RefreshCountText();
                return true;
            }
        }

        //used to find an empty slot in inventory
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            ItemInfoDisplay itemInSlot = slot.GetComponentInChildren<ItemInfoDisplay>();
            if (!itemInSlot) 
            {
                //if no item in slot - add item
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;
    }

    public void MinusItem(Item item)
    {
        //used to find a slot with the same item type and count lower then the maximum number
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            ItemInfoDisplay itemInSlot = slot.GetComponentInChildren<ItemInfoDisplay>();
            if (itemInSlot != null &&
                itemInSlot.item == item
                && itemInSlot.item.isStackable
                && itemInSlot.itemCount < itemInSlot.item.maxStack && itemInSlot.itemCount > 1)
            {
                //if item already in slot - reduce stack
                itemInSlot.itemCount--;
                itemInSlot.RefreshCountText();
                return;
            }
        }

        //used to find an empty slot in inventory
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            ItemInfoDisplay itemInSlot = slot.GetComponentInChildren<ItemInfoDisplay>();
            if (itemInSlot.item == item)
            {
                //if no item in slot - add item
                Destroy(itemInSlot.gameObject);
            return;
            }
        }
    }

    public void SpawnNewItem(Item item, InventorySlot slot)
    {
        //spawn new item, the object prefab and the slot where to put it
        GameObject newItem = Instantiate(inventoryPrefab, slot.transform);
        ItemInfoDisplay inventoryItem = newItem.GetComponent<ItemInfoDisplay>(); //we get access to the ItemInfoDisplay script
        inventoryItem.InitialiseItem(item); //we assign the item that is needed to be setted
    }

    //if we want a slot selection by input other then mouse, we can implement it here
    // for now just changes values based in mouse input and slot
    public void ChangeSelectedSlot(int value)
    {
        selectedSlot = value;
    }
}
