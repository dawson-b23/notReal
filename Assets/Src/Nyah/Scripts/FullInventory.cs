/*
 * FullInventory.cs
 * Nyah Nelson
 * conditions for when inventory is full and the 'x' is clicked
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * FullInventory class to handle situations when the inventory is full and the user wants to remove one weapon, but not equip it
 * Inherits from InventoryMenu to override the weaponButtonClick function
 * 
 * member functions:
 * Awake() - checks to make sure there is not more than one instance of the singleton
 * weaponButtonClick(Button clickedButton) - function called when a red x button is clicked on the inventory menu
 */
public class FullInventory : InventoryMenu
{
    private void Awake()
    {
        // check if there is only one instance
        // if there is an instance, and it isn't this, delete it
        if (inventoryMenuInstance != null && inventoryMenuInstance != this)
        {
            Destroy(this);
            Debug.Log("error: extra Inventory menu instance");
        }
    }

    //public void weaponButtonClick(Button clickedButton)
    public override void weaponButtonClick(Button clickedButton)
    {
        if (clickedButton == removeButton1)
        {
            Debug.Log("first full button is clicked");
            // remove weapon that is in the first index of the array
            if (!Inventory.inventoryInstance.removeWeaponOnly(0))
            {
                // deactivate the button if no weapon was readded to inventory (so if removeweapon returns false)
                deactivateButton(0);
            }
        }
        else if (clickedButton == removeButton2)
        {
            Debug.Log("second full button is clicked");
            // remove the weapon that is in the second index of the array
            if (!Inventory.inventoryInstance.removeWeaponOnly(1))
            {
                // deactivate the button if no weapon was readded to inventory (so if removeweapon returns false)
                deactivateButton(1);
            }

        }
        else if (clickedButton == removeButton3)
        {
            Debug.Log("third full button is clicked");
            // remove the weapon that is in the third index of the array
            if (!Inventory.inventoryInstance.removeWeaponOnly(2))
            {
                // deactivate the button if no weapon was readded to inventory (so if removeweapon returns false)
                deactivateButton(2);
            }

        }
        else
        {
            Debug.Log("button clicked was not in the inventory menu!!");
        }
    }

}
