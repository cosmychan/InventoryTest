using UnityEngine;

// this is the Weapon class.
// Here we will store information related to the weapon type, whether it has durability or not, how durable (how many hits) and damage
// this class add to the initial Item class data/info

public enum WeaponType {Sword, Bow, Staff}

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Inventory/Item/NonConsumable/Weapon", order = 0)]
public class Weapon : Item
{
    public WeaponType weaponType; // the type of the weapon
    public bool useWeaponDurability; // if this weapon is "limited" in use or not
    public int weaponDurability; // if useWeaponDurability set true, from 1 to 10 hits, otherwise ignored
    public int weaponDamage; //the weapon's amount of damage per hit
}