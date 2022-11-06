using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfileObserver : Observer
{
    // constructor attaches the observer to the subject
    /*public PlayerProfileObserver(Subject subject)
    {
        this.subject = subject;
        this.subject.Attach(this);
    }*/

    public PlayerProfileObserver(Inventory inventory)
    {
        this.inventory = inventory;
        this.inventory.Attach(this);
    }

    public override void fullUpdate()
    {
        // if inventory is full, change the color to green
        PlayerProfile.profileInstance.inventoryText.color = Color.green;
    }

    public override void notFullUpdate()
    {
        // if inventory is not full, change the color back to white
        PlayerProfile.profileInstance.inventoryText.color = Color.white;
    }
}
