using UnityEngine;

// this is the Potion class. Here we will store information related to the potion type (for health or mana)
// and the amount it restores
// this class add to the initial Item class data/info

public enum PotionType {Health, Mana}

[CreateAssetMenu(fileName = "NewPotion", menuName = "Inventory/Item/Consumable/Potion", order = 0)]
public class Potion : Item
{
    [Header("Potion Info")]
    public PotionType potionType; //defines the type of the potion
    public int restoreAmount; //the amount it will restore per 1 potion
}
