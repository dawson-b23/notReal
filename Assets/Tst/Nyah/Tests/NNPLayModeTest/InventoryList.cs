/*
 * InventoryList.cs
 * Nyah Nelson
 * A copy of inventory class to use for testing
 *
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
 * InventoryList class to access inventory features
 * 
 * member variables:
 * maxInventory - maximum value for inventory list
 * inventoryItems - inventory list
 * InventoryList() - constructor to create a new inventory list
 * CreateItem() - create and return a new item to add to inventory
 * AddInventory(Item item) - add item to list
 * RemoveInventory() - remove item from list
 * IsFull() - check if inventory is full
 *
public class InventoryList : MonoBehaviour
{
    // public for test
    public int maxInventory = 20; 
    public List<Item> inventoryItems;

    // constructor initializes list
    public InventoryList()
    {
        inventoryItems = new List<Item>(maxInventory);
        //Debug.Log("Inventory initialized"); // works
    }

    //public Item CreateItem(ItemType itemtype)
    // create and return a new item
    public Item CreateItem()
    {
        //Item item = new Item { itemType = itemtype, itemAmount = 1 };
        Item item = new Item { itemAmount = 1 };

        return item;
    }

    // add item to inventory
    public void AddInventory(Item item)
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

    //public void RemoveInventory(Item item)
    // remove item from inventory
    public void RemoveInventory()
    {
        // if there is at least one item in inventory, you can remove it
        if (inventoryItems.Count > 0)
        {
            Item lastItem = inventoryItems.Last();
            inventoryItems.Remove(lastItem);
        }
    }

    public bool IsFull()
    {
        if (inventoryItems.Count < maxInventory)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
*/