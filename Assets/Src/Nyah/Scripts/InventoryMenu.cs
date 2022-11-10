/*
 * InventoryMenu.cs
 * Nyah Nelson
 * Inventory Menu functions 
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * InventoryMenu class to handle the inventory menu buttons
 * 
 * member variables:
 * menuBackground - object reference to the inventory menu background 
 * menuBackgroundColor - image reference to the inventory menu background color
 * inventoryButton (s) - 3 buttons to store the weapons
 * removeButton (s) - 3 buttons to remove a weapon and not equip it
 * 
 * member functions:
 * activateButton(int buttonNumber) - activate a buttons
 * deactivateButton(int buttonNumber) - deactivate a button
 * weaponButtonClick(Button clickedButton) - call the remove weapon function for the correct index based on the button clicked
 */
public class InventoryMenu : MenuManager
{
    // references to the inventory menu background 
    public GameObject menuBackground;
    public Image menuBackgroundColor;
    public Button inventoryButton1;
    public Button inventoryButton2;
    public Button inventoryButton3;
    public Button removeButton1;
    public Button removeButton2;
    public Button removeButton3;
    // public Button removeButton;

    // inventory menu (on the HUD) singleton
    public static InventoryMenu inventoryMenuInstance { get; private set; }

    private void Awake()
    {
        // check if there is only one instance
        // if there is an instance, and it isn't this, delete it
        if (inventoryMenuInstance != null && inventoryMenuInstance != this)
        {
            Destroy(this);
            Debug.Log("error: extra Inventory menu instance");
        }
        else
        {
            inventoryMenuInstance = this;
        }

        // initially disable all inventory buttons (since there is nothing in inventory at the beginning of the game)
        inventoryButton1.gameObject.SetActive(false);
        inventoryButton2.gameObject.SetActive(false);
        inventoryButton3.gameObject.SetActive(false);
        removeButton1.gameObject.SetActive(false);
        removeButton2.gameObject.SetActive(false);
        removeButton3.gameObject.SetActive(false);
    }

    public void Start()
    {
        // get the image of the inventory menu to edit it later
        menuBackgroundColor = menuBackground.GetComponent<Image>();

    }

    public void activateButton(int buttonNumber)
    {
        switch(buttonNumber)
        {
            case 0:
                inventoryButton1.gameObject.SetActive(true);
                break;
            case 1:
                inventoryButton2.gameObject.SetActive(true);
                break;
            case 2:
                inventoryButton3.gameObject.SetActive(true);
                break;
        }
    }

    public void deactivateButton(int buttonNumber)
    {
        switch (buttonNumber)
        {
            case 0:
                inventoryButton1.gameObject.SetActive(false);
                break;
            case 1:
                inventoryButton2.gameObject.SetActive(false);
                break;
            case 2:
                inventoryButton3.gameObject.SetActive(false);
                break;
        }
    }

    //public void weaponButtonClick(Button clickedButton)
    public virtual void weaponButtonClick(Button clickedButton)
    {
        if (clickedButton == inventoryButton1)
        {
            Debug.Log("first button is clicked");
            // remove weapon that is in the first index of the array
            if (!Inventory.inventoryInstance.removeWeapon(0))
            {
                // deactivate the button if no weapon was readded to inventory (so if removeweapon returns false)
                deactivateButton(0);
            }
        }
        else if (clickedButton == inventoryButton2)
        {
            Debug.Log("second button is clicked");
            // remove the weapon that is in the second index of the array
            if (!Inventory.inventoryInstance.removeWeapon(1))
            {
                // deactivate the button if no weapon was readded to inventory (so if removeweapon returns false)
                deactivateButton(1);
            }
        }
        else if (clickedButton == inventoryButton3)
        {
            Debug.Log("third button is clicked");
            // remove the weapon that is in the third index of the array
            if (!Inventory.inventoryInstance.removeWeapon(2))
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
