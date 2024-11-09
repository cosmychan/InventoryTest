using System.Collections.Generic;
using UnityEngine;

//we use this to store our inventory items and their quantity
//it also contains the InventorySlot class which is used for storing items in one list (easier to access them later)

[CreateAssetMenu(fileName = "NewInventory", menuName = "Inventory/BaseInventory", order = 1)]
public class Inventory : ScriptableObject
{
    public List<Slot> inventoryItems = new List<Slot>(); //the list of items
    public void AddItem(Item _item, int _amount)
    {
        bool _hasItem = false; //used for checking if the inventory contains duplicates
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].item == _item)
            {
                inventoryItems[i].AddAmount(_amount); //if there is a duplicate - we add in amount
                _hasItem = true;
                break;
            }
        }
        if (!_hasItem)
        {
            inventoryItems.Add(new Slot(_item, _amount)); //if there is no duplicate, we add the item to the list
        }
    }
}

[System.Serializable]
public class Slot
{
    public Item item; //the item itself
    public int amount; //the amount of it
    public Slot(Item _item, int _amount)
    {
        item = _item; //we assign the current item
        amount = _amount; //assign the current amount
    }

    public void AddAmount(int _value)
    {
        amount += _value; //add in value of the current item
    }
}
