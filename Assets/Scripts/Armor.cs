
using UnityEngine;

// this is the Armor class.
// Here we will store information related to the weapon type, whether it has durability or not, how durable (how many hits) and damage
// this class add to the initial Item class data/info

public enum ArmorType { Head, Chest, Legs}

[CreateAssetMenu(fileName = "NewArmor", menuName = "Inventory/Item/NonConsumable/Armor", order = 1)]
public class Armor : Item
{
    public ArmorType armorType; // the type of armor
    public int shieldAmount; // the amount it adds to the player's shield/protection
    public bool useArmorDurability; // whether it is "limited" in use or not
    public int armorDurability; // if is used durability, from 1 to 10 hits
}
