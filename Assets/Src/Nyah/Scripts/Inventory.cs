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
 * member variables:
 * maxInventory - maximum value for inventory list
 * inventoryItems - inventory list
 * Inventory() - constructor to create a new list
 * createItem() - create and return a new item to add to inventory
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
        //Debug.Log("Inventory initialized"); // works
    }

    //public Item CreateItem(ItemType itemtype)
    /* 
     * create a new item to be added to inventory
     * return the item
     */
    public Item createItem()
    {
        //Item item = new Item { itemType = itemtype, itemAmount = 1 };
        Item item = new Item { itemAmount = 1 };

        return item;
    }

    // add an item to inventory list
    public void addInventory(Item item)
    {
        // check if inventory is full 
        if (!isFull())
        {
            //Debug.Log("inventory not full; adding item");
            inventoryItems.Add(item);
        }
        else
        {
            //Debug.Log("inventory full; cant add item");
        }
        // check if weapon exists as a type
        /*if (WeaponExists(item))
        {
            // check if inventory is full 
            if (!IsFull())
            {
                //Debug.Log("inventory not full; adding item");
                inventoryItems.Add(item);
            }
            else
            {
                //Debug.Log("inventory full; cant add item");
            }
        }*/
    }

    // remove an item from inventory list
    public void removeInventory()
    {
        // if there is at least one item in inventory, you can remove it
        if (inventoryItems.Count > 0)
        {
            Item lastItem = inventoryItems.Last();
            inventoryItems.Remove(lastItem);
        }
        /*if (inventoryItems.Count > 0)
        {
            Item lastItem = inventoryItems.Last();
            // if weapon exists as a weapon
            if (WeaponExists(lastItem))
            {
                // check inventory for this weapon
                if (CheckInventory(lastItem))
                {
                    inventoryItems.Remove(lastItem);
                }
            }
        }*/
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

    /* do i need this?
     * public int ItemCount()
    {
        return inventoryItems.Count;
    }*/

    // check if weapon exists as a type 
    /*public bool WeaponExists(Item item)
    {
        if (item.itemType == ItemType.Melee || item.itemType == ItemType.Gun)
        {
            //Debug.Log(item.itemType);
            return true;
        }
        else
        {
            //Debug.Log("weapon does not exist");
            return false;
        }
    }*/

    // check if a weapon exists in inventory to use it
    /*public bool CheckInventory(Item item)
    {
        // check if it is in inventory (if the amount is greater than 0)
        if (item.itemAmount > 0)
        {
            //Debug.Log(item.itemAmount);
            return true;
        }
        else
        {
            //Debug.Log("you do not have this weapon in inventory");
            return false;
        }
    } */

}
