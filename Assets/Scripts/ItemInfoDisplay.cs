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

    //we check the item info type/class for use. Eat food, use potion, equip, etc.
    public void CheckItemInfo()
    {
        switch (item)
        {
            case Food food:
                PlayerStats.OnEat?.Invoke(food); //eat food
                Inventorymanager.OnMinusItem?.Invoke(item);
                break;
            case Potion potion:
                PlayerStats.OnUsePotion?.Invoke(potion); //use potion
                Inventorymanager.OnMinusItem?.Invoke(item);
                break;
            case Resources resource:
                Debug.LogError("resource"); //here we can implement the craft mecanic
                break;
            case Armor armor:
                EquipManager.OnEquipItem?.Invoke(item, armor.armorType.ToString());
                //PlayerStats.OnEquipItem?.Inv
                break;
            case Weapon weapon:
                EquipManager.OnEquipItem?.Invoke(item, "Weapon"); //we can write it similar to Armor case later
                break;
        }
    }
}

