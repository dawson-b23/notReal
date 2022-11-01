/*
 * InventoryMenu.cs
 * Nyah Nelson
 * Inventory Menu functions (open and close)
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * InventoryMenu class to access the inventory menu
 * 
 * member functions:
 * openInventory() - open menu
 * closeInventory() - close menu
 * pauseGame() - pause game after menu is opened
 * resumeGame() - resume game after menu is opened
 */
public class InventoryMenu : MenuManager
{
    public static InventoryMenu Instance { get; private set; }

    private void Awake()
    {
        // check if there is only one instance
        // if there is an instance, and it isn't this, delete it
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void Start()
    {
        // initialize menu items to zero
        updateMelee(0);
        updateRange(0);
    }

    public TextMeshProUGUI meleeText, rangeText;
    public int meleeValue, rangeValue;

    // inventory display in HUD 
    public void openInventory()
    {
        Debug.Log("Opening inventory menu");
        openMenu(Menu.InventoryMenu);
        pauseGame();
    }

    // close inventory display in HUD
    public void closeInventory()
    {
        Debug.Log("Closing inventory menu");
        closeMenu(Menu.InventoryMenu);
        resumeGame();
    } 

    // pause game 
    public void pauseGame()
    {
        // open inventory menu
        openMenu(Menu.InventoryMenu);
        // pause/stop game
        Time.timeScale = 0f;
        Debug.Log("open inventory menu");
    }

    // protected override void ResumeGame()
    // resume game
    public void resumeGame()
    {
        // close inventory menu
        closeMenu(Menu.InventoryMenu);
        // resume game
        Time.timeScale = 1f;
        Debug.Log("close inventory menu");
    }

    // update melee value in inventory menu
    public void updateMelee(int updateAmount)
    {
        meleeValue += updateAmount;
        meleeText.text = "x " + meleeValue;
    }

    // update ranged weapon value in inventory menu
    public void updateRange(int updateAmount)
    {
        rangeValue += updateAmount;
        rangeText.text = "x " + rangeValue;
    }
}
