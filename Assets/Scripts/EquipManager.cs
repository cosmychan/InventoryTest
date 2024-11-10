using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public InventorySlot[] equipSlots; //we will need those to load and equip the necessary items from the saves
    [SerializeField] private List<GameObject> placeholderArmor;
    public static Action<Item, string> OnEquipItem;

    public void Start()
    {
        GameObject playerView = GameObject.Find("PlayerView");
        for (int i = 0; i < playerView.transform.childCount; i++)
        {
            placeholderArmor.Add(playerView.transform.GetChild(i).gameObject);
        }
    }

    private void OnEnable()
    {
        OnEquipItem += CheckEquipped;
    }

    private void OnDisable()
    {
        OnEquipItem -= CheckEquipped;
    }

    public void CheckEquipped(Item item, string placeholderName)
    {
        //equip item
        for (int i = 0; i < placeholderArmor.Count; i++)
        {
            if (placeholderArmor[i].name == placeholderName) //check if the item type corresponds to slot type
            {
                //we check if there is no other item spawned in the placeholder, if is - we delete the old one and spawn a new one
                if (placeholderArmor[i].transform.childCount > 0)
                {

                    Destroy(placeholderArmor[i].transform.GetChild(0).gameObject);
                }
                else
                {
                    SpawnArmor(item, placeholderArmor[i]);
                }
            }
        }
    }

    public void SpawnArmor(Item item, GameObject placeholder)
    {
        //spawn the object prefab at the specified placeholder
        GameObject newItem = Instantiate(item.itemPrefac, placeholder.transform);
        newItem.transform.position = placeholder.transform.position;
        newItem.transform.rotation = placeholder.transform.rotation;
    }
}
