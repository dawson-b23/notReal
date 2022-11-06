using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
