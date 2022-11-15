/*
 * PlayerProfile.cs
 * Nyah Nelson
 * Player Profile information that is displayer on the HUD
 */

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
 * PlayerProfile class to display player information on the player profile object on the HUD
 * 
 * member variables:
 * PlayerProfile Instance - singleton
 * TextMeshProUGUI objects for health, money, EXP, and inventory text
 * int values for health, money, EXP, and inventory
 * 
 * member functions:
 * Awake() - thread safe singleton check
 * updateHealth() - update health value
 * updateMoney() - update money value
 * updateEXP() - update EXP value
 * updateInventory() - update inventory value
 */
public class PlayerProfile : MonoBehaviour
{
    public TextMeshProUGUI healthText, moneyText, expText, inventoryText;
    public static int healthValue = 0, moneyValue = 0, expValue = 0;
    public int inventoryValue = 0;

    /* thread safe singleton
     * other scripts can still use the singleton, but
     * only this class can get and set the singleton instance
     */
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
        updateEXP(0);
        updateInventory(0); 
    }

    /* update health value in HUD
     * this function is called when the player health increases (shop) or decreases (enemies)
     * adds the updated amount to the static variable
     * displays the total updated amount on the HUD
     */
    public void updateHealth(int updateAmount)
    {
        healthValue += updateAmount;
        healthText.text = "HEALTH: " + healthValue;
    }

    /* update money value in HUD
     * this functin is called when the player defeats an enemy and gains honey
     * adds the updated amount to the static variable
     * displays the updated value on the HUD
     */
    public void updateMoney(int updateAmount)
    {
        moneyValue += updateAmount;
        moneyText.text = "HONEY: " + moneyValue;
    }

    /* update EXP in HUD
     * this function is called when the player gains EXP
     * adds the updated amount to the static variable
     * displays the updated value on the HUD
     */
    public void updateEXP(int updateAmount)
    {
        expValue += updateAmount;
        expText.text = "EXP: " + expValue;
    }

    /* update inventory in HUD
     * this function when a weapon is added or removed to inventory
     * adds the amount to the variable
     * displayes the updates value on the HUD
     */
    public void updateInventory(int updateAmount)
    {
        inventoryValue += updateAmount;
        inventoryText.text = "INVENTORY: " + inventoryValue;
    }
}
