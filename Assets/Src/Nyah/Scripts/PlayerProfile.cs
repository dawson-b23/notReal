/*
 * PlayerProfile.cs
 * Nyah Nelson
 * Player Profile information
 */

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Graphs;
using UnityEngine;
using UnityEngine.UI;

/*
 * PlayerProfile class to display player information
 * 
 * member variables:
 * 
 */
public class PlayerProfile : MonoBehaviour
{
    // thread safe singleton
    // other scripts can still use the singleton, but
    // only this class can get and set the singleton instance
    public static PlayerProfile Instance { get; private set; }

    public TextMeshProUGUI healthText, moneyText, levelText, inventoryText;
    public int healthValue = 0, moneyValue = 0, levelValue = 0, inventoryValue = 0;

    private void Awake()
    {
        // check if there is only one instance
        // if there is an instance, and it isn't this, delete it
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void Start()
    {
        updateHealth(0);
        updateMoney(0);
        updateLevel(0);
        updateInventory(0);

        //StartCoroutine(Profile());

    }

    /*public IEnumerator Profile()
    {
        UpdateHealth(5);
        UpdateMoney(5);
        UpdateLevel(5);
        UpdateInventory(5);

        yield return new WaitForSeconds(1f);

        UpdateHealth(-1);
        UpdateMoney(-1);
        UpdateLevel(-1);
        UpdateInventory(-1);
    }*/

    public void updateHealth(int updateAmount)
    {
        healthValue += updateAmount;
        healthText.text = "Health: " + healthValue;
    }

    public void updateMoney(int updateAmount)
    {
        moneyValue += updateAmount;
        moneyText.text = "Money: " + moneyValue;
    }

    public void updateLevel(int updateAmount)
    {
        levelValue += updateAmount;
        levelText.text = "Level: " + levelValue;
    }

    public void updateInventory(int updateAmount)
    {
        inventoryValue += updateAmount;
        inventoryText.text = "Inventory: " + inventoryValue;
    }

    // to access : PlayerProfile.Instance.[public variable or public method]

    // game object in HUD canvas: panel with text

    // float healthbarvalue = Singleton.Instance.playerhealth;
}
