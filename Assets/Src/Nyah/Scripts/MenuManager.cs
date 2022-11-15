/*
 * MenuManager.cs
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
 * pauseGame() - pauses the game by setting the timescale to 0
 * resumeGame() - resumes the game by setting the tiemscale to 1
 */
public class MenuManager : MonoBehaviour
{
    
    // reference to the menu objects
    public GameObject mainMenu, pauseMenu, optionsMenu, inventoryMenu, helpMenu, skillTreeMenu;

    /* 
     * opens a menu by activating the correct game object assigned in the inspector
     * takes the menu name as a parameter
     */
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
            case Menu.SkillTreeMenu:
                skillTreeMenu.SetActive(true);
                break;
        }
    }

    /*
     * cloes a menu by deactivating the game object
     */
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
            case Menu.SkillTreeMenu:
                skillTreeMenu.SetActive(false);
                break;
        }
    }

    /*
     * virtual function
     * sets the timescale to 0 to pause the game
     */
    public virtual void pauseGame()
    {
        Time.timeScale = 0f;
        Debug.Log("paused game, no menu opened");
    }

    /*
     * virtual function
     * sets the timescale to 1 to resume the game
     */
    public virtual void resumeGame()
    {
        Time.timeScale = 1f;
        Debug.Log("resume game, no menu closed");
    }


}
