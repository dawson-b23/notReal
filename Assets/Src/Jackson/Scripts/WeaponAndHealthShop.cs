/*
 * Jackson Baldwin - 11/09/2022        
 * WeaponandHealthShop.cs - NotReal        
 *                                    
 * Test Script for early prototype of Shop
 * used by ShopHoneyTest.cs for Boundary Test
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Shop Class
 * Handles Buying Weapons and Health by Boundary Test
 *
 */
public class Shop : MonoBehaviour
{
    //tries to buy a weapon, returns leftover playerHoney after purchase/decline of purchase
    public int buyWeapon(int playerHoney)
    {
        //all weapons in this test cost 20 honey
        int requiredHoney = 20;

        //if player honey is greater than required honey and player will not end up with negative income...
        if (playerHoney >= requiredHoney && (playerHoney - requiredHoney) >= 0)
        {
            playerHoney -= requiredHoney;
            Debug.Log("Got weapon!");
            Debug.Log(playerHoney);
        }
        else
        {
            Debug.Log("Not enough honey :(");
        }

        return playerHoney;
    }
    //tries to buy health, returns leftover playerHoney after purchase/decline of purchase
    public int buyHealth(int playerHoney)   
    {
        //all health items in this test cost 5 honey
        int requiredHoney = 5;
        //if player honey is greater than required honey and player will not end up with negative income...
        if (playerHoney >= requiredHoney && (playerHoney - requiredHoney) >= 0)
        {
            playerHoney -= requiredHoney;
            Debug.Log("Got Health!");
        }
        else
        { 
            Debug.Log("Not enough honey :(");
        }

        return playerHoney;
    }

}