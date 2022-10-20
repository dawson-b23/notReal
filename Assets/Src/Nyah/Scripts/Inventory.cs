using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;
using static UnityEditor.Progress;
using System.Linq;

public class Inventory : MonoBehaviour
{
    //private List<Item> inventoryItems = new List<Item>();

    public int maxInventory = 20; // make private after test
    public List<Item> inventoryItems;

    // constructor initializes list
    public Inventory()
    {
        inventoryItems = new List<Item>(maxInventory);
        //Debug.Log("Inventory initialized"); // works
    }

    public Item CreateItem(ItemType itemtype)
    {
        // can i do itemAmount++?
        Item item = new Item { itemType = itemtype, itemAmount = 1 };

        return item;
    }

    public void AddInventory(Item item)
    {
        // check if weapon exists as a type
        if (WeaponExists(item))
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
        }
    }

    //public void RemoveInventory(Item item)
    public void RemoveInventory()
    {
        if (inventoryItems.Count > 0)
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
        }
    }

    public bool IsFull()
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

    // check if weapon exists as a type 
    public bool WeaponExists(Item item)
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
    }

    // check if a weapon exists in inventory to use it
    public bool CheckInventory(Item item)
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

        /* can also use
         * inventoryItems.Contains(ItemType.Gun);
         * ?? try it
         */
    }

    public int ItemCount()
    {
        return inventoryItems.Count;
    }

}
