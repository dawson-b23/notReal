/*
 * PlayerProfileObserver.cs
 * Nyah Nelson
 * Observer for when inventory is full to change the inventory text on the HUD to green
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * PlayerProfileObserver class to change the color of the inventory text when inventory is full
 * Inherits from Observer class to override functions
 * 
 * member functions:
 * fullUpdate() - change text color of inventory value in the player profile to green
 * notFullUpdate() - change text color of inventory value in the player profile to white
 */
public class PlayerProfileObserver : Observer
{
    public PlayerProfileObserver(Inventory inventory)
    {
        this.inventory = inventory;
        this.inventory.Attach(this);
    }

    /*
 * override function inherited from the Observer class
 * called when inventory is full
 * changes the color of the inventory text on the player profile to green when inventory is full
 */
    public override void fullUpdate()
    {
        // if inventory is full, change the color to green
        PlayerProfile.profileInstance.inventoryText.color = Color.green;
    }

    /*
 * override function inherited from the observer class
 * called when inventory is no longer full
 * changes the color of the inventory text on the player profile to white when inventory is full
 */
    public override void notFullUpdate()
    {
        // if inventory is not full, change the color back to white
        PlayerProfile.profileInstance.inventoryText.color = Color.white;
    }
}
