using UnityEngine;

// this is the Item base class. Here we will store the basic information like the item's name; image; description;
// whether it's consumable (food, potion) or not (armor, weapons) or is used for crafting (wood, rocks)
// this clss is inherited by the Potion, Food, Resources, Armor and Weapon classes

public enum ItemType {Consumable, NonConsumable, Craft}

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item/BaseItem", order = 0)]
public class Item : ScriptableObject
{
    [Header("Basic Info")]
    public string itemName; //the item's name to show in inventory
    public Sprite itemImage; //the image that will be shown in the inventory
    [TextArea] public string itemDescription; //description to show in inventory

    //[Header("Item Type")]
    //public ItemType itemType; //to define if the item is consumable or not
}
