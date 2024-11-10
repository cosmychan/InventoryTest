using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            UIManager.OnInventoryToggle?.Invoke(true);
            Time.timeScale = 0f;
        } else if (Input.GetButtonDown("Back"))
        {
            UIManager.OnInventoryToggle?.Invoke(false);
            Time.timeScale = 1f;
        }
    }
}
