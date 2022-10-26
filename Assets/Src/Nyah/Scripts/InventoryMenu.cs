/*
 * InventoryMenu.cs
 * Nyah Nelson
 * Inventory Menu functions (open and close)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * InventoryMenu class to access the inventory menu
 * 
 * member variables:
 * openInventory() - open menu
 * closeInventory() - close menu
 * pauseGame() - pause game after menu is opened
 * resumeGame() - resume game after menu is opened
 */
public class InventoryMenu : MenuManager
{
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
}
