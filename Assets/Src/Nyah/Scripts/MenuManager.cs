using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    // reference to the menu objects
    [SerializeField]
    GameObject mainMenu, pauseMenu, optionsMenu, inventoryMenu;

    // function to open a menu 
    // public void OpenMenu(Menu menu, GameObject callingMenu)
    public void OpenMenu(Menu menu)
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
        }
    }

    // function to close a menu
    public void CloseMenu(Menu menu)
    {
        // close menu
        switch (menu)
        {
            case Menu.MainMenu:
                mainMenu.SetActive(false);
                break;
            case Menu.PauseMenu:
                // figure out how to pause game
                //ResumeGame();
                pauseMenu.SetActive(false);
                break;
            case Menu.OptionsMenu:
                optionsMenu.SetActive(false);
                break;
            case Menu.InventoryMenu:
                inventoryMenu.SetActive(false);
                break;
        }
    }

    protected virtual void PauseGame()
    {
        Time.timeScale = 0f;
        Debug.Log("pause game");
    }

    protected virtual void ResumeGame()
    {
        Time.timeScale = 1f;
        Debug.Log("resume game");
    }

    
}
