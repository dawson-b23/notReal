/*
 * MenuManage.cs
 * Nyah Nelson
 * Basic functions for all menus
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * MenuManager class to manage basic functions for all menus
 * 
 * member variables:
 * mainMenu - main menu game object
 * pauseMenu - pause menu game object
 * optionsMenu - options menu game object
 * inventoryMenu - inventory menu game object
 * helpMenu - help menu game object
 * 
 * member functions:
 * openMenu(Menu menu) - open a menu
 * closeMenu(Menu menu) - close a menu
 */
public class MenuManager : MonoBehaviour
{
    
    // reference to the menu objects
    [SerializeField]
    GameObject mainMenu, pauseMenu, optionsMenu, inventoryMenu, helpMenu;

    // public void OpenMenu(Menu menu, GameObject callingMenu)
    // functions to open a menu
    public void openMenu(Menu menu)
    {
        // open menu
        switch(menu)
        {
            case Menu.MainMenu:
                mainMenu.SetActive(true);
                break;
            case Menu.PauseMenu:
                pauseMenu.SetActive(true);
                break;
            case Menu.OptionsMenu:
                optionsMenu.SetActive(true);
                break;
            case Menu.InventoryMenu:
                inventoryMenu.SetActive(true);
                break;
            case Menu.HelpMenu:
                helpMenu.SetActive(true);
                break;
        }
    }

    // function to close a menu
    public void closeMenu(Menu menu)
    {
        // close menu
        switch (menu)
        {
            case Menu.MainMenu:
                mainMenu.SetActive(false);
                break;
            case Menu.PauseMenu:
                pauseMenu.SetActive(false);
                break;
            case Menu.OptionsMenu:
                optionsMenu.SetActive(false);
                break;
            case Menu.InventoryMenu:
                inventoryMenu.SetActive(false);
                break;
            case Menu.HelpMenu:
                helpMenu.SetActive(false);
                break;
        }
    }

    /* or make them abstract???
     * protected virtual void PauseGame();
     * protected virtual void ResumeGame();
    */
    /*protected virtual void PauseGame()
    {
        Time.timeScale = 0f;
        Debug.Log("pause game");
    }

    protected virtual void ResumeGame()
    {
        Time.timeScale = 1f;
        Debug.Log("resume game");
    } */

    
}
