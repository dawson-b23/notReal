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
using System.Linq;

/*
 * Inventory class to store, add, and remove weapons from the inventory
 * Inventory acts as the subject for the observer patterns
 * the observers observe when inventory is full or not
 * 
 * member variables:
 * maxInventory - maximum value for inventory list
 * weaponList - weapon list
 * full[] - array to keep track of whether the "slots" of inventory are full or not
 * slots[] - array to keep track of the weapons in each slot
 * playerObject - player reference
 * inventoryInstance - inventory singleton
 * observers - observer list (for the observer pattern)
 * 
 * member functions:
 * Attach(Observer observer) - add observers to the list
 * Detach(Observer observer) - remove observers from the list
 * Notify() - notify observers when a state is changed (when inventory is full or not)
 * addWeapon(AbstractWeapon abstractWeapon) - add a weapon to the list
 * removeWeapon(int indexOfWeapon) - remove and equip a weapon
 * removeWeaponOnly(int indexOfWeapon) - remove but do not equip a weapon
 * isFull() - returns true if inventory is full
 * isEmpty() - returns true if inventory is empty 
 * getInventory() - returns the inventory instance 
 * inventoryAmount() - returns the current amount in inventory
 */
public class Inventory : MonoBehaviour
{
    // PUBLIC VARIABLES

    /* inventory singleton instance
     * private set allows for only this class to be able to set the instance to something (done in the Awake function)
     * keyword get retrieves the variable inventoryInstance
     * why i chose the singleton pattern:
     * I chose the singleton pattern because I only wanted one instance of objects, such as the player profile, HUD, and inventory system. 
     * That way only the original isntance would be updated and saved throughout scenes
     */
    public static Inventory inventoryInstance { get; private set; }

    // list to store amount of weapons
    public List<AbstractWeapon> weaponList;

    // array used to check if there is an item in one of the inventory menu slots(buttons)
    // false means not full 
    public bool[] full = {false, false, false};

    // array to store the actual weapons in the correct slot on the inventory menu
    public AbstractWeapon[] slots;

    // reference to the player
    public GameObject playerObject;

    // PRIVATE VARIABLES

    // observer list to keep track of which classes are observers
    private List<Observer> observers = new List<Observer>();

    // max amount allowed for inventory (weapons)
    private int maxInventory = 3;

    /* thread safe singleton
     * other scripts can still use the singleton, but
     * only this class can get and set the singleton instance
     */
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
            // set the instance of the class to the singleton
            inventoryInstance = this;
        }
    }

    /*
     * adds an observer to the observer list
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
     * constructor initializes the weaponlist and attaches the observer classes
     */
    public Inventory()
    {
        // initializes list to be the size of maxInventory
        weaponList = new List<AbstractWeapon>(maxInventory);
        // attach observers to this instance of the inventory
        Attach(new PlayerProfileObserver(this));
        Attach(new InventoryMenuObserver(this));
        Attach(new FullInventoryObserver(this));
    }

    /*
     * add an abstract weapon to the list
     * checks if the abstractweapon actuall exists
     * if the weapon exists, checks if inventory is full
     * if it is not full, then adds weapon to the inventory list,
     * updates player profile, changes the status of the full array to true (since it is now full)
     * assigns the correct index in slots to store the weapon,
     * updates the inventory menu to activate the correct button
     * after a weapon is added, checks if inventory is full, if it is full, the function notifies the observers to change their state
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

                        // slot is now full
                        full[i] = true;
                        // add to abstract weapon array
                        slots[i] = abstractWeapon;

                        // activate the correct button on the menu
                        InventoryMenu.inventoryMenuInstance.activateButton(i);
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
     * called in the weaponButtonClick function for the inventory menu
     * parameter - index of the weapon in the slots array to be removed
     * returns - false if a weapon was not readded to inventory
     * or true if a weapon was readded to inventory (meaning that the weapon the player is currently equiped with was swapped with one that was in inventory)
     * 
     * checks if the playerobject exists (to be able to equip the player with the weapon)
     * checks if inventory is empty (if it is, then no weapon can be removed)
     * if inventory is not full, then assignes an abstract weapon to the weapon to be removed from the slots array
     * checks if inventory is full (if it is, it will notify observers because after a weapon is removed, inventory is no longer full and the observers need to change state)
     * equips the player with the desired weapon
     * the equipWeapon function returns the old weapon
     * if the old weapon is null (meaning the player was not equiped with a weapon), then change HUD display and do not activate the button
     * if the old weapon is not null, then assign the old weapon to the slot of the new weapon and activate the correct button
     * return true to let the weaponButtonClick function know to not deactivate the button
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
                        InventoryMenu.inventoryMenuInstance.activateButton(indexOfWeapon);
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
                        InventoryMenu.inventoryMenuInstance.activateButton(indexOfWeapon);
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
     * removes a weapon but do not equip it 
     * called when the remove button is clicked to drop a weapon and open a slot in inventory
     * parameter - index of slots to remove weapon from
     * returns false since a weapon is not readded because the player is not equipped with a new weapon
     * 
     * checks if inventory is not empty
     * retrieves the correct weapon from the paramter sent int
     * removes the weapon from the list, assigns the full array to be false (empty), decreases the value on the player profile
     * notifies observers to change state
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