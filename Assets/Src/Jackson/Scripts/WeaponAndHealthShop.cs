using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    // private PlayerController player = null;

    int playerHoney = 0;


    private void Start()
    {

        // player = GameObject.FindGameObjectWithTag("Player");
    }


    public int BuyWeapon(int playerHoney)
    {
        int requiredHoney = 20;

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

    public int BuyHealth(int playerHoney)   //will be voids with updates
    {
        int requiredHoney = 5;
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