using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // remove weapon but do not equip weapon
    /*public  void removeWeapon2(int indexOfWeapon)
    {
        // bool weaponReturn = false;

        // retrieve the correct weapon
        AbstractWeapon weaponToBeRemoved = slots[indexOfWeapon];
        if (weaponToBeRemoved == null)
        {
            Debug.Log("weapon is null");
        }
        else
        {
            Debug.Log("index of weapon to be removed is " + indexOfWeapon);
            // if inventory is full (then the displays are red), then change them back to initial color after removing a weapon
            if (isFull())
            {
                weaponList.Remove(weaponToBeRemoved);
                // slot is now open
                full[indexOfWeapon] = false;
                PlayerProfile.profileInstance.updateInventory(-1);
                //weaponReturn = false;
                Notify();
            }
            else // inventory is not full, but it should be
            {
                Debug.Log("error: trying to remove a weapon and not equip it when inventory is not full");
            }
        }
    }

    public void removeButtonClick()
    {
        // deactivate normal buttons
        deactivateButton(0);
        deactivateButton(1);
        deactivateButton(2);

        // activate full buttons
        activateButton(3);
        activateButton(4);
        activateButton(5);

        // pause game so player can choose a weapon with time
        pauseGame();
    }

     */

}
