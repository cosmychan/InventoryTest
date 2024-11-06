using UnityEngine;

// this is the Food class. Here we will store information related to the food type 
// Simple (like an apple or a carrot for example) or Complex (for anything that was made via cooking, for example soup
// Poison is for the food that may be consumed to cover hunger, but will give a decrease in other stats (in this case a negave valut int the buff amount field)
// the Buff type defines whether the food can give a buff (in health or mana for example) or not; and the buff amount
// this class add to the initial Item class data/info

public enum FoodType { Simple, Complex, Poison}
public enum BuffType {None, Health, Mana}

[CreateAssetMenu(fileName = "NewFood", menuName = "Inventory/Item/Consumable/Food", order = 1)]

public class Food : Item
{
    public FoodType foodType; //defines the type of food
    public int fullAmount; //how much will the food cover the player's hunger
    public BuffType buffType; //the type of buff the food gives 
    public int buffAmount; //the amount of buff it gives
}
