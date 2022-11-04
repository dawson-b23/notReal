/*
 * Inventory.cs
 * Nyah Nelson
 * Manage the Inventory List
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
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
public class Inventory : MonoBehaviour
{
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
    }

    private int maxInventory = 3;
    private List<AbstractWeapon> weaponList;

    public bool[] full;
    public GameObject[] slots;

    // constructor initializes list
    public Inventory()
    {
        weaponList = new List<AbstractWeapon>(maxInventory);
    }

    /*
     * add an abstract weapon to the list
     * first check if inventory is full
     * if it isn't then add weapon to inventory list,
     * update player profile
     * update inventory menu for each individual weapon
     * 
     */
    //public void addWeapon(AbstractWeapon weaponToBeAdded, GameObject weaponButton)
    public void addWeapon(AbstractWeapon abstractWeapon)
    {
        if (!isFull())
        {
            weaponList.Add(abstractWeapon);
            PlayerProfile.profileInstance.updateInventory(1);
        }
        
    }

    /*
     * remove an  abstract weapon from inventory after a request is made
     * check if the inventory list is not empty
     * check what weapon the request was for
     * remove the weapon if it exists in the inventory list
     * 
     */
    public void removeWeapon(AbstractWeapon weaponToBeRemoved)
    {
        if (inventoryAmount() < maxInventory)
        {
            weaponList.Remove(weaponToBeRemoved);
        }
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
