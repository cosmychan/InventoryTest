using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//we use this class to drag and drop items across the inventory slots


public class DragableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public Image image; //the image of the item object
    public Transform parentAfterDrag; //this holds the info related to the object parent

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.LogError("start drag");
        parentAfterDrag = transform.parent; //get the curent parent (also helps return the object to initial slot if not positioned correctly
        transform.SetParent(transform.root); //change parent to canvas
        transform.SetAsLastSibling(); //put as last in order to be visually on top of everything in the canvas
        image.raycastTarget = false; //turn off so raycast allows to see the object(slot) under the mouse
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.LogError("dragging");
        transform.position = Input.mousePosition; //the dragging itself based on mouse position
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.LogError("stop drag");
        transform.SetParent(parentAfterDrag); //set the parent of the item from canvas to other object(slot) at the end of dragging
        image.raycastTarget = true; //turn back on so it's possible to interact wih the item again
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.LogError("entered");
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            GameObject _pressed = eventData.pointerClick; //get the object on which pressed/clicked
            ItemInfoDisplay item = _pressed.GetComponent<ItemInfoDisplay>(); //get the ItemDisplayInfo script from the object
            item.CheckItemInfo(item.item);
        }
    }
}
