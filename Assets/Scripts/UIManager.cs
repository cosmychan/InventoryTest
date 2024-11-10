using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// here we control/update the health, mana values;
// send info about the item name and description to show in inventory ui
// control the toggle of on/off of the interaction panel

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Slider _manaSlider;
    [SerializeField] private Slider _hungerSlider;
    [SerializeField] private TextMeshProUGUI _itemNameText;
    [SerializeField] private TextMeshProUGUI _itemDescriptionText;
    [SerializeField] private GameObject _interaction;
    [SerializeField] private GameObject _deathScreen;
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private GameObject _playerStats;

    public static Action<int> OnHealthChanged;
    public static Action<int> OnManaChanged;
    public static Action<int> OnHungerChanged;
    public static Action<string, string> OnItemInfoUpdated;
    public static Action<bool> OnInteractionTextToggled;
    public static Action<bool> OnDeath;
    public static Action<bool> OnInventoryToggle;

    public void Awake()
    {
        _interaction.SetActive(false); //we turn off the interaction panel
        _itemDescriptionText.text = ""; //make the text empty
    }

    public void OnEnable()
    {
        // we subscribe to the ui events for further use
        OnHealthChanged += UpdateHealth;
        OnManaChanged += UpdateMana;
        OnHungerChanged += UpdateHunger;
        OnItemInfoUpdated += SetItemInfo;
        OnInteractionTextToggled += ToggleInteractionText;
        OnDeath += ToggleDeathScreen;
        OnInventoryToggle += ToggleInventory;
    }

    public void OnDisable()
    {
        // unsubscribe from events to avoid nulls
        OnHealthChanged -= UpdateHealth;
        OnManaChanged -= UpdateMana;
        OnHungerChanged -= UpdateHunger;
        OnItemInfoUpdated -= SetItemInfo;
        OnInteractionTextToggled -= ToggleInteractionText;
        OnDeath -= ToggleDeathScreen;
        OnInventoryToggle -= ToggleInventory;
    }

    public void UpdateHealth(int healthValue)
    {
        //update health slider value
        _healthSlider.value = healthValue;
    }

    public void UpdateMana(int manaValue)
    {
        //update mana slider value
        _manaSlider.value = manaValue;
    }

    public void UpdateHunger(int hungerValue)
    {
        //update hunger slider value
        _hungerSlider.value = hungerValue;
    }

    public void SetItemInfo(string name, string description)
    {
        //update item name and description
        _itemNameText.text = name;
        _itemDescriptionText.text = description;
    }

    public void ToggleInteractionText(bool isActive)
    {
        //turn on/off the interaction panel
        _interaction.SetActive(isActive);
    }

    public void ToggleDeathScreen(bool isActive)
    {
        //turn on/off the interaction panel
        _deathScreen.SetActive(isActive);
    }

    public void ToggleInventory(bool isActive)
    {
        //turn on/off the interaction panel
        _inventoryPanel.SetActive(isActive);
        _playerStats.SetActive(!isActive);
    }
}
