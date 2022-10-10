using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;
using static UnityEditor.Progress;

public class Inventory : MenuManager
{
    /*public static Inventory instance;

    public void Awake()
    {
        instance = this;
    } */

    //private List<Item> inventoryItems = new List<Item>();
    // make array ??
    public int maxInventory = 20; // make private after test
    private List<Item> inventoryItems;
    // add list for other weapon ??

    // constructor initializes list
    public Inventory()
    {
        inventoryItems = new List<Item>(maxInventory);
        //Debug.Log("Inventory initialized"); // works

        // add to player class
        // Inventory inventory;
        // in awake function:
        // inventory = new Inventory();
        // if weapon is picked up, CreateItem()
        // AddInventory(item)

        //AddInventory(new Item { itemType = Item.ItemType.Melee, itemAmount = 1 });
        //AddInventory(new Item { itemType = Item.ItemType.Gun, itemAmount = 1 });
        //Debug.Log(inventoryItems[0].itemAmount);
        //Debug.Log(inventoryItems[1].itemType);

        //Item item = CreateItem(ItemType.Melee);

        //AddInventory(item);
        //Debug.Log(inventoryItems.Count);

        //RemoveInventory(item);

        //RemoveInventory(Item.ItemType.Melee);
        //Debug.Log("removing one from inventory");
        //Debug.Log(inventoryItems.Count);

    }

    public Item CreateItem(ItemType itemtype)
    {
        Item item = new Item { itemType = itemtype, itemAmount = 1 };

        return item;
    }

    // inventory display in HUD 
    public void OpenInventory()
    {
        Debug.Log("Opening inventory menu");
        OpenMenu(Menu.InventoryMenu);
        PauseGame();
    }

    public void CloseInventory()
    {
        Debug.Log("Closing inventory menu");
        CloseMenu(Menu.InventoryMenu);
        ResumeGame();
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
            // for testing
            // AddInventory(new Item { itemType = Item.ItemType.Melee, itemAmount = 1 });
            // Debug.Log(inventoryItems.Count)
        }
    }

    public void RemoveInventory(Item item)
    {
        // if weapon exists as a weapon
        if (WeaponExists(item))
        {
            // check inventory for this weapon
            if(CheckInventory(item))
            {
                inventoryItems.Remove(item);
            }
        }

        // for testing
        // RemoveInventory()
        // Debug.Log(inventoryItems.Count)
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
        //int count = item.itemAmount;
        return inventoryItems.Count;
    }

    /* 
    need to update inventory in the upgrade
    inventory in the update inventory funtion
    (i will use this function for testing)
    */

    // update inventory
    // add or remove a weapon
    // increase or decrease inventory value

    // if an object is picked up
    // (in weaponpickup function)
    // add 1 to inventory (inventory.melee++)

    // if an object is requested from inventory
    // check inventory for object
    // if true, remove 1 from inventory (inventory.melee--)


}
