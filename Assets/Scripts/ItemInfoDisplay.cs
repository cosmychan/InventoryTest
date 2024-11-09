using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoDisplay : MonoBehaviour
{
    public Item item; //the item in/for slot/inventory
    public Image itemImage; //the item in/for slot/inventory

    private void Start()
    {
        itemImage = GetComponent<Image>();
    }

    public void SendItemInfo()
    {
        UIManager.OnItemInfoUpdated(item.itemName, item.itemDescription);
    }

    public void EmptyItemInfo()
    {
        UIManager.OnItemInfoUpdated("", "");
    }

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        itemImage.sprite = newItem.itemImage;
    }

    public void DisplayItemInfo(Item item)
    {
        // Display the common fields for all items
        Debug.Log("Item Name: " + item.itemName);
        Debug.Log("Description: " + item.itemDescription);

        switch (item)
        {
            case Food food:
                break;
            case Potion potion:
                break;
            case Resources resource:
                break;
            case Armor armor:
                break;
            case Weapon weapon:
                break;
        }
    }
}

