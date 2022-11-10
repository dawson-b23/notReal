/*
 * InventoryMenuObserver.cs
 * Nyah Nelson
 * Observer for when inventory is full to change the inventory menu background to green
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * InventoryMenuObserver class to change the color of the inventory menu when inventory is full
 * Inherits from Observer class to override functions
 * 
 * member functions:
 * fullUpdate() - change background color of inventory menu to green
 * notFullUpdate() - change background color of inventory menu to black
 */
public class InventoryMenuObserver : Observer
{
    public InventoryMenuObserver(Inventory inventory)
    {
        this.inventory = inventory;
        this.inventory.Attach(this);
    }

    public override void fullUpdate()
    {
        // if inventory is full, change the color to green
        InventoryMenu.inventoryMenuInstance.menuBackgroundColor.color = Color.green;
    }

    public override void notFullUpdate()
    {
        // if inventory is not full, change the color back to black
        InventoryMenu.inventoryMenuInstance.menuBackgroundColor.color = Color.black;
    }
}
