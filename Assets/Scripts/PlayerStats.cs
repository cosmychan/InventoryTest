using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _healthMax;
    [SerializeField] private int _mana;
    [SerializeField] private int _manaMax;
    [SerializeField] private int _hunger; //the slider which shows how hungry the player is
    [SerializeField] private int _hungerMaximum; //the maximum value when saturation full to avoid excess
    [SerializeField] private int _shield; //the maximum value when saturation full to avoid excess

    public static Action<int> OnDamageReceived;
    public static Action<int> OnManaUse;
    public static Action<Food> OnEat;
    public static Action<Potion> OnUsePotion;


    public void OnEnable()
    {
        // we subscribe for further use
        OnDamageReceived += TakeDamage;
        OnManaUse += UseMana;
        OnEat += EatFood;
        OnUsePotion += UsePotion;
    }

    public void OnDisable()
    {
        //unsubscribe to avoid nulls
        OnDamageReceived -= TakeDamage;
        OnManaUse -= UseMana;
        OnEat -= EatFood;
        OnUsePotion -= UsePotion;
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

    public void AddHealth(int amount)
    {
        //add health and change value in UI
        //check so there won't be more than necessary value
        if (_health < _healthMax)
        {
            _health += amount;
            UIManager.OnHealthChanged?.Invoke(_health);
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

    public void AddMana(int amount)
    {
        //add mana and change value in UI
        //check so there won't be more than necessary value
        if (_mana < _manaMax)
        {
            _mana += amount;
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

    public void EatFood(Food food)
    {
        DecreaseHunger(food.fullAmount);

        switch (food.foodType)
        {
            case FoodType.Simple:
                Debug.LogError("no debuff no buff");
                break;
            case FoodType.Complex:
                if (food.buffType == BuffType.Mana)
                {
                    AddMana(food.buffAmount);
                } else if (food.buffType == BuffType.Health)
                {
                    AddHealth(food.buffAmount);
                }
                break;
            case FoodType.Poison:
                if (food.debuffType == DebuffType.Mana)
                {
                    UseMana(food.buffAmount);
                }
                else if (food.debuffType == DebuffType.Health)
                {
                    TakeDamage(food.buffAmount);
                }
                break;
        }
    }

    public void UsePotion(Potion potion)
    {
        switch (potion.potionType)
        {
            case PotionType.Health:
                AddHealth(potion.restoreAmount);
                break;
            case PotionType.Mana:
                AddMana(potion.restoreAmount);
                break;
        }
    }

}
