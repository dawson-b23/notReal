/*
 * Inventory.cs
 * Nyah Nelson
 * Manage the Inventory List
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.Progress;
using System.Linq;

/*
 * Inventory class to update the inventory list
 * 
 * member variables:
 * maxInventory - maximum value for inventory list
 * inventoryList - inventory list
 * full[] - array to keep track of whether the slots of inventory are full or not
 * slots[] - array to keep track of the slots for inventory
 * 
 * member functions:
 * Inventory() - constructor to create a new list
 * addInventory(Item item) - add item to list
 * removeInventory() - remove item from list
 * isFull() - check if inventory is full
 */


// need to make inventory abstract to work for the observe? try it without the abstract
public class Inventory : MonoBehaviour
{
    private int maxInventory = 3;
    public List<AbstractWeapon> weaponList;
    // used to check if there is an item in one of the inventory menu slots(buttons)
    public bool[] full;
    // keeps hold of the weapons
    public AbstractWeapon[] slots;
    // reference to the player
    public GameObject playerObject;
    // reference to inventory menu

    // inventory singleton
    public static Inventory inventoryInstance { get; private set; }

    // thread safe singleton implementation
    private void Awake()
    {
        // check if there is only one instance
        // if there is an instance, and it isn't this, delete it
        if (inventoryInstance != null && inventoryInstance != this)
        {
            Destroy(this);
            Debug.Log("error: extra Inventory instance");
        }
        else
        {
            inventoryInstance = this;
        }

        // get player object
        // playerObject = GameObject.FindWithTag("Player");
    }

    // observer list to keep track of which classes are observers
    private List<Observer> observers = new List<Observer>();

    /*
     * adds an observer to the list
     */
    public void Attach(Observer observer)
    {
        observers.Add(observer);
    }

    /*
     * removes an observer from the list
     */
    public void Detach(Observer observer)
    {
        observers.Remove(observer);
    }

    /*
     * update the observers depending on the notification type
     */
    public void Notify()
    {
        // when an item is removed or added notify
        // check if inventory amount is full or not
        if (inventoryAmount() < 3) // not full
        {
            // notify observers that it is not full
            foreach (Observer observer in observers)
            {
                observer.notFullUpdate();
            }
        }
        else // inventory full
        {
            // notify observers that it is full
            foreach (Observer observer in observers)
            {
                observer.fullUpdate();
            }

        }
    }

    /*
     * constructor initializes the weaponlist and attached the observers
     */
    public Inventory()
    {
        // initializes list
        weaponList = new List<AbstractWeapon>(maxInventory);
        // attach observers to this instance of the inventory
        Attach(new PlayerProfileObserver(this));
        Attach(new InventoryMenuObserver(this));
        Attach(new FullInventoryObserver(this));
    }

    /*
     * add an abstract weapon to the list
     * first check if inventory is full
     * if it isn't then add weapon to inventory list,
     * update player profile
     * update inventory menu for each individual weapon
     * 
     */
    public void addWeapon(AbstractWeapon abstractWeapon)
    {
        if (abstractWeapon == null)
        {
            Debug.Log("abstract weapon to be added is null");
        }
        else
        {
            // check if inventory is not full
            if (!isFull())
            {
                for (int i = 0; i < maxInventory; i++)
                {
                    if (full[i] == false) // one of the slots is empty
                    {
                        weaponList.Add(abstractWeapon);
                        PlayerProfile.profileInstance.updateInventory(1);
                        Debug.Log("weapon added at index " + i);
                        // activate the correct button on the menu
                        //inventoryMenuReference.activateButton(i);
                        InventoryMenu.inventoryMenuInstance.activateButton(i);

                        // slot is now full
                        full[i] = true;
                        slots[i] = abstractWeapon;
                        break;
                    }
                }

                // check if inventory is full after adding a weapon
                if (isFull())
                {
                    // inventory is full so notify observers
                    Notify();
                }
            }
            else // inventory is full
            {
                Debug.Log("Inventory is full");
            }
        }

    }

    /*
     * called when the inventory button is clicked
     * remove an  abstract weapon from inventory after a request is made
     * check if the inventory list is not empty
     * check what weapon the request was for
     * remove the weapon if it exists in the inventory list
     * 
     */
    public bool removeWeapon(int indexOfWeapon)
    {
        bool weaponReturn = false;

        // check if player object is null
        if (playerObject == null)
        {
            playerObject = GameObject.FindWithTag("Player");

        }

        // check if inventory is not empty
        if (!isEmpty())
        {
            // retrieve the correct weapon
            AbstractWeapon weaponToBeRemoved = slots[indexOfWeapon];
            if (weaponToBeRemoved == null)
            {
                Debug.Log("weapon is null");
            }
            else
            {
                Debug.Log("index of weapon to be removed is " + indexOfWeapon);
                // if inventory is full (then the displays are green), then change them back to initial color after removing a weapon by notifying observers
                if (isFull())
                {
                    weaponList.Remove(weaponToBeRemoved);
                    AbstractWeapon readdedWeapon = playerObject.GetComponent<PlayerController>().equipWeapon(weaponToBeRemoved);
                    if (readdedWeapon != null)
                    {
                        // add the old item back to inventory
                        weaponList.Add(readdedWeapon);
                        slots[indexOfWeapon] = readdedWeapon;
                        // a weapon was returned so don't deactiviate button
                        weaponReturn = true;
                        Debug.Log("readded weapon to index " + indexOfWeapon);
                    }
                    else // there was no weapon returned, so decrease the value in inventory and change the slot to empty
                    {
                        full[indexOfWeapon] = false;
                        PlayerProfile.profileInstance.updateInventory(-1);
                    }
                    // notify observers
                    Notify();
                }
                else // inventory is not full, so no need to notify the observers
                {
                    weaponList.Remove(weaponToBeRemoved);
                    AbstractWeapon readdedWeapon = playerObject.GetComponent<PlayerController>().equipWeapon(weaponToBeRemoved);
                    if (readdedWeapon != null)
                    {
                        // add the old item back to inventory
                        weaponList.Add(readdedWeapon);
                        slots[indexOfWeapon] = readdedWeapon;
                        // a weapon was returned so don't deactiviate button
                        weaponReturn = true;
                        Debug.Log("readded weapon to index " + indexOfWeapon);
                    }
                    else // there was no weapon returned, so decrease the value in inventory and change the slot to empty
                    {
                        full[indexOfWeapon] = false;
                        PlayerProfile.profileInstance.updateInventory(-1);
                    }
                }
            }
        }
        else
        {
            Debug.Log("Inventory is empty; you cannot remove anything");
        }

        return weaponReturn;
    }


    /*
     * remove a weapon but do not equip it 
     */
    public bool removeWeaponOnly(int indexOfWeapon)
    {
        Debug.Log("removeweapononly function called");

        bool weaponReturn = false;

        // check if player object is null
        if (playerObject == null)
        {
            playerObject = GameObject.FindWithTag("Player");

        }

        // check if inventory is not empty
        if (!isEmpty())
        {
            // retrieve the correct weapon
            AbstractWeapon weaponToBeRemoved = slots[indexOfWeapon];
            if (weaponToBeRemoved == null)
            {
                Debug.Log("weapon is null");
            }
            else
            {
                Debug.Log("index of weapon to be removed is " + indexOfWeapon);
                // if inventory is full (then the displays are green), then change them back to initial color after removing a weapon by notifying observers
                if (isFull())
                {
                    // remove weapon from list 
                    weaponList.Remove(weaponToBeRemoved);
                    // decrease the value in inventory and change the slot to empty
                    full[indexOfWeapon] = false;
                    PlayerProfile.profileInstance.updateInventory(-1);
                    // notify observers
                    Notify();
                }
                else // inventory is not full, so no need to notify the observers
                {
                    weaponList.Remove(weaponToBeRemoved);
                    // decrease the value in inventory and change the slot to empty
                    full[indexOfWeapon] = false;
                    PlayerProfile.profileInstance.updateInventory(-1);
                }
            }
        }
        else
        {
            Debug.Log("Inventory is empty; you cannot remove anything");
        }

        return weaponReturn;
    }

    /*
     * check if inventory is full
     * return true if it is full
     * return false if it is not full
     */
    public bool isFull()
    {
        if (weaponList.Count < maxInventory)
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

    /*
     * check if inventory is empty (zero weapons)
     * return true if it is empty
     * return false if it is not empty
     */
    public bool isEmpty()
    {
        if (weaponList.Count == 0)
            return true;
        else
            return false;
    }

    /*
     * return the single instance of inventory
     */
    public static Inventory getInventory()
    {
        return inventoryInstance;
    }

    /*
     * return the amount of weapons in the list
     */
    public int inventoryAmount()
    {
        return weaponList.Count;
    }
}