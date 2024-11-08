using UnityEngine;

// this is the Resources class.
// Here we will store information related to the resource type
// this class can be updated and enriched depending on the amount of resources, their type and characteristics needed.
// for example added the Plant type
// this class add to the initial Item class data/info

public enum ResourceType { Wood, Rock, Bone, Plant }
public enum PlantType { Ivy, Branch}

[CreateAssetMenu(fileName = "NewResource", menuName = "Inventory/Item/Craft/Resouces", order = 0)]
public class Resources : Item
{
    public ResourceType resourceType; //the type of the resources
    public PlantType plantType; // the type of plant

    //check if resource type is Plant
    public bool IsPlant() => resourceType == ResourceType.Plant;
}
