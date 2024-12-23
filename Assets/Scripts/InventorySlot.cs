using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//we use this in order to "drop" the item from one slot to the other, for the "snapping" effect
// depending on the slot - we do addiotional checks for droppoing items from inventory or assigning specific items to specific slots
// example weapon to the weapon slot or armor of a certain type to the coresponding slot (head armor - to head armor slot)

public class InventorySlot : MonoBehaviour, IDropHandler/*, IPointerClickHandler*/
{
    public bool isBaseSlot; //if no additional check required
    public bool isThrowZone; //check if the zone is for throwing out of the inventory
    public bool notArmor; //check if is NonConsumable and a weapon
    public ItemType itemType; //check if is NonConsumable (for weapon and armor slots)
    public ArmorType armorType; //check armor type for specific armor slots
    //check item type for armor and weapon
    //check equipped and add stats
    private GameObject _dropped;

    public void OnDrop(PointerEventData eventData)
    {
        if (isThrowZone)
        {
            //throw item from inventory
            _dropped = eventData.pointerDrag; //get the dropped object
            ItemInfoDisplay item = _dropped.GetComponent<ItemInfoDisplay>(); //get the ItemDisplayInfo script from the object
            GameObject.Instantiate(item.item.itemPrefac, GameObject.FindWithTag("Player").transform.position, GameObject.FindWithTag("Player").transform.rotation); //instantiate object prefab in scene
            if (item.item.isStackable && item.itemCount < item.item.maxStack && item.itemCount > 1)
            {
                item.itemCount--;
                item.RefreshCountText();
            }
            else
            {
                Destroy(_dropped.gameObject);
            }
            
        } else
        {
            if (isBaseSlot)
            {
                if (transform.childCount == 0) //so there wouldn't be 2 items in one slot
                {
                    _dropped = eventData.pointerDrag; //get the dropped object
                    DragableItem dragable = _dropped.GetComponent<DragableItem>(); //get the dragable script from the object
                    dragable.parentAfterDrag = transform; //set new parent
                }
            }
            else
            {
                _dropped = eventData.pointerDrag; //get the dropped object
                ItemInfoDisplay item = _dropped.GetComponent<ItemInfoDisplay>(); //get the dragable script from the object
                CheckItemType(item.item, item);
            }
            
        }
    }

    public void CheckItemType(Item item, ItemInfoDisplay itemInfo)
    {
        if (itemType == ItemType.NonConsumable)
        {
            //_dropped = eventData.pointerDrag; //get the dropped object
            DragableItem dragable = _dropped.GetComponent<DragableItem>(); //get the dragable script from the object

            if (notArmor)
            {
                //get data from draggable item to check if the items corresponds to the weapon slot
                
                if (item  is Weapon)
                {
                    dragable.parentAfterDrag = transform; //set new parent
                }                
            }
            else
            {
                Armor armorItem = item as Armor;
                if (armorItem.armorType == armorType)
                {
                    switch (armorType)
                    {
                        case ArmorType.Head:
                            //get data from draggable item to check if the items corresponds to the slot
                            dragable.parentAfterDrag = transform; //set new parent
                            itemInfo.CheckItemInfo();
                            break;
                        case ArmorType.Chest:
                            //get data from draggable item to check if the items corresponds to the slot
                            dragable.parentAfterDrag = transform; //set new parent
                            itemInfo.CheckItemInfo();
                            break;
                        case ArmorType.Legs:
                            //get data from draggable item to check if the items corresponds to the slot
                            dragable.parentAfterDrag = transform; //set new parent
                            itemInfo.CheckItemInfo();
                            break;
                    }
                }
            }
        }
    }
}
