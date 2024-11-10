using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject equipViewCam;
    
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            UIManager.OnInventoryToggle?.Invoke(true);
            equipViewCam.SetActive(true);
            Time.timeScale = 0f;
        } else if (Input.GetButtonDown("Back"))
        {
            UIManager.OnInventoryToggle?.Invoke(false);
            equipViewCam.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
