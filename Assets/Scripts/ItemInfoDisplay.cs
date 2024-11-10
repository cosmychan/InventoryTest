using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoDisplay : MonoBehaviour
{
    public Item item; //the item in/for slot/inventory
    public int itemCount = 1; //the amount of the item
    public Text counterText;
    public bool isConsumable;

    public void SendItemInfo()
    {
        UIManager.OnItemInfoUpdated(item.itemName, item.itemDescription); //for UI to display the name and description when mouse over item
    }

    public void EmptyItemInfo()
    {
        UIManager.OnItemInfoUpdated("", ""); //clear text after mouse no longer on item
    }

    public void InitialiseItem(Item newItem)
    {
        //is used to show image of item in slot
        item = newItem; //assign item
        gameObject.GetComponent<Image>().overrideSprite = newItem.itemImage; //assign image/sprite from scribtable object
        RefreshCountText();
    }

    public void RefreshCountText()
    {
        counterText.text = itemCount.ToString();
        if (itemCount > 1)
        {
            counterText.gameObject.SetActive(true);
        }
        else
        {
            counterText.gameObject.SetActive(false);
        }
    }

    public void CheckItemInfo(Item item)
    {
        switch (item)
        {
            case Food food:
                PlayerStats.OnEat?.Invoke(food);
                Inventorymanager.OnMinusItem?.Invoke(item);
                break;
            case Potion potion:
                PlayerStats.OnUsePotion?.Invoke(potion);
                Inventorymanager.OnMinusItem?.Invoke(item);
                break;
            case Resources resource:
                isConsumable = false;
                break;
            case Armor armor:
                isConsumable = false;
                break;
            case Weapon weapon:
                isConsumable = false;
                break;
        }
    }
}

