/*
 * FullInventoryObserver.cs
 * Nyah Nelson
 * Observer for when inventory is full to display the red 'x' buttons
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * FullInventoryObserver class to display the red 'x' buttons when notified
 * Inherits from Observer class to override functions
 * 
 * member functions:
 * fullUpdate() - activate buttons when inventory is full
 * notFullUpdate() - deactivate buttons when inventory is not full
 */
public class FullInventoryObserver : Observer
{
    /*
     * constructor 
     * attaches this observer to the list of observers in the inventory script
     */
    public FullInventoryObserver(Inventory inventory)
    {
        this.inventory = inventory;
        this.inventory.Attach(this);
    }

    /*
     * override function inherited from the Observer class
     * called when inventory is full
     * activates the remove buttons to give the player an option to drop a weapon when inventory is full
     */
    public override void fullUpdate()
    {
        // if inventory is full, activiate full button
        InventoryMenu.inventoryMenuInstance.removeButton1.gameObject.SetActive(true);
        InventoryMenu.inventoryMenuInstance.removeButton2.gameObject.SetActive(true);
        InventoryMenu.inventoryMenuInstance.removeButton3.gameObject.SetActive(true);
    }

    /*
     * override function inherited from the observer class
     * called when inventory is no longer full
     * deactivates the remove buttons since you are only allowed to remove a weapon when inventory is full
     */
    public override void notFullUpdate()
    {
        // if inventory is not full, deactivate full button
        InventoryMenu.inventoryMenuInstance.removeButton1.gameObject.SetActive(false);
        InventoryMenu.inventoryMenuInstance.removeButton2.gameObject.SetActive(false);
        InventoryMenu.inventoryMenuInstance.removeButton3.gameObject.SetActive(false);
    }
}
