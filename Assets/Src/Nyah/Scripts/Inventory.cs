/*
 * Inventory.cs
 * Nyah Nelson
 * Manage the Inventory List
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;
using static UnityEditor.Progress;
using System.Linq;

/*
 * Inventory class to update the inventory list
 * 
 * member variables and functions:
 * maxInventory - maximum value for inventory list
 * inventoryItems - inventory list
 * Inventory() - constructor to create a new list
 * addInventory(Item item) - add item to list
 * removeInventory() - remove item from list
 * isFull() - check if inventory is full
 */
public class Inventory : MonoBehaviour
{
    private int maxInventory = 20; // make private after test
    private List<Item> inventoryItems;

    // constructor initializes list
    public Inventory()
    {
        inventoryItems = new List<Item>(maxInventory);
        Debug.Log("Inventory initialized"); // works
    }

    // add an item to inventory list
    public void addInventory()
    {

        // check if inventory is full 
        if (!isFull())
        {
            //Debug.Log("inventory not full; adding item");
            // create a new itm
            Item item = new Item { itemAmount = 1 };
            // add item to list
            inventoryItems.Add(item);
            // update inventory value on player profile
            PlayerProfile.Instance.updateInventory(1);
            // figure out how to update inventory menu (for each weapon individually)
        }
        else
        {
            Debug.Log("inventory full; cant add item");
        }
    }

    // remove an item from inventory list
    public void removeInventory()
    {
        // if there is at least one item in inventory, you can remove it
        if (inventoryItems.Count > 0)
        {
            // retrieve the last item in the list (the one that will be removed)
            Item lastItem = inventoryItems.Last();
            // remove item from list
            inventoryItems.Remove(lastItem);
            // update inventory value on player profile
            PlayerProfile.Instance.updateInventory(-1);
        }
    }

    /*
     * check if inventory is full
     * return true if it is full
     * return false if it is not full
     */
    public bool isFull()
    {
        if (inventoryItems.Count < maxInventory)
        {
            //Debug.Log("inventory not full");
            return false;
        }
        else
        {
            //Debug.Log("inventory full");
            return true;
        }
    }

}
