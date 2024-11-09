using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _mana;
    [SerializeField] private int _hunger; //the slider which shows how hungry the player is
    [SerializeField] private int _hungerMaximum; //the maximum value when saturation full to avoid excess
    [SerializeField] private int _shield; //the maximum value when saturation full to avoid excess

    public static Action<int> OnDamageReceived;
    public static Action<int> OnManaUse;
    public static Action<int> OnEat;


    public void OnEnable()
    {
        // we subscribe for further use
        OnDamageReceived += TakeDamage;
        OnManaUse += UseMana;
        OnEat += DecreaseHunger;
    }

    public void OnDisable()
    {
        //unsubscribe to avoid nulls
        OnDamageReceived -= TakeDamage;
        OnManaUse -= UseMana;
        OnEat -= DecreaseHunger;
    }

    void Start()
    {
        //to update the initial values of the sliders for the player stats UI
        UIManager.OnHealthChanged?.Invoke(_health);
        UIManager.OnManaChanged?.Invoke(_mana);
        UIManager.OnHungerChanged?.Invoke(_hunger);
    }

    public void TakeDamage(int damage)
    {
        //apply damange and change value in UI
        //we also check so the values don't become negative and call the death screen
        if (_health >= damage)
        {
            _health -= damage;
            UIManager.OnHealthChanged?.Invoke(_health);
        }
        else
        {
            _health = 0;
            UIManager.OnDeath(true);
        }
        
    }

    public void UseMana(int amount)
    {
        //reduce mana and change value in UI
        //check so there won't be negative value
        if (_mana >= amount)
        {
            _mana -= amount;
            UIManager.OnManaChanged?.Invoke(_mana);
        } 
    }

    public void DecreaseHunger(int amount)
    {
        //increase saturation and change value in Ui
        if (_hunger < _hungerMaximum)
        {
            _hunger += amount;
            UIManager.OnHungerChanged?.Invoke(_hunger);
        }
        
    }

}
