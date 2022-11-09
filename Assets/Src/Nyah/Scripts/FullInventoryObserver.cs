using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullInventoryObserver : Observer
{
    public FullInventoryObserver(Inventory inventory)
    {
        this.inventory = inventory;
        this.inventory.Attach(this);
    }

    public override void fullUpdate()
    {
        // if inventory is full, activiate full button
        InventoryMenu.inventoryMenuInstance.removeButton1.gameObject.SetActive(true);
        InventoryMenu.inventoryMenuInstance.removeButton2.gameObject.SetActive(true);
        InventoryMenu.inventoryMenuInstance.removeButton3.gameObject.SetActive(true);
    }

    public override void notFullUpdate()
    {
        // if inventory is not full, deactivate full button
        InventoryMenu.inventoryMenuInstance.removeButton1.gameObject.SetActive(false);
        InventoryMenu.inventoryMenuInstance.removeButton2.gameObject.SetActive(false);
        InventoryMenu.inventoryMenuInstance.removeButton3.gameObject.SetActive(false);
    }
}
