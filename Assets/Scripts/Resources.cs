using UnityEngine;

// this is the Resources class.
// Here we will store information related to the resource type
// this class add to the initial Item class data/info

public enum ResourceType { Wood, Rock }

[CreateAssetMenu(fileName = "NewResource", menuName = "Inventory/Item/Craft/Resouces", order = 0)]
public class Resources : Item
{
    public ResourceType resourceType; //the type of the resources
}
