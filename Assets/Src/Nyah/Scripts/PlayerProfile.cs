/*
 * PlayerProfile.cs
 * Nyah Nelson
 * Player Profile information
 */

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
 * PlayerProfile class to display player information
 * 
 * member variables:
 * PlayerProfile Instance - singleton
 * TextMeshProUGUI objects for health, money, level, and inventory text
 * int values for health, money, level, and inventory
 * 
 * member functions:
 * Awake() - thread safe check
 * updateHealth() - update health value
 * updateMoney() - update money value
 * updateLevel() - update level value
 * updateInventory() - update inventory value
 */
public class PlayerProfile : MonoBehaviour
{
    // thread safe singleton
    // other scripts can still use the singleton, but
    // only this class can get and set the singleton instance
    public static PlayerProfile profileInstance { get; private set; }

    private void Awake()
    {
        // check if there is only one instance
        // if there is an instance, and it isn't this, delete it
        if (profileInstance != null && profileInstance != this)
        {
            Destroy(this);
        }
        else
        {
            profileInstance = this;
        }

        // initialize values in HUD
        updateMoney(0);
        updateLevel(0);
        updateInventory(0); 
    }

    public TextMeshProUGUI healthText, moneyText, levelText, inventoryText;
    public int healthValue = 0, moneyValue = 0, levelValue = 0, inventoryValue = 0;

    // update health value in HUD
    public void updateHealth(int updateAmount)
    {
        healthValue += updateAmount;
        healthText.text = "HEALTH: " + healthValue;
    }

    // update money value in HUD
    public void updateMoney(int updateAmount)
    {
        moneyValue += updateAmount;
        moneyText.text = "HONEY: " + moneyValue;
    }

    // update level in HUD
    public void updateLevel(int updateAmount)
    {
        levelValue += updateAmount;
        levelText.text = "LEVEL: " + levelValue;
    }

    // update inventory in HUD
    public void updateInventory(int updateAmount)
    {
        inventoryValue += updateAmount;
        inventoryText.text = "INVENTORY: " + inventoryValue;
    }

    // to access : PlayerProfile.Instance.[public variable or public method]

    // game object in HUD canvas: panel with text
}
