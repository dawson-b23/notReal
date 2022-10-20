using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryMenu : MenuManager
{
    // inventory display in HUD 
    public void OpenInventory()
    {
        Debug.Log("Opening inventory menu");
        OpenMenu(Menu.InventoryMenu);
        PauseGame();
    }

    public void CloseInventory()
    {
        Debug.Log("Closing inventory menu");
        CloseMenu(Menu.InventoryMenu);
        ResumeGame();
    } 


    public void PauseGame()
    {
        // open inventory menu
        OpenMenu(Menu.InventoryMenu);
        // pause/stop game
        Time.timeScale = 0f;
        Debug.Log("open inventory menu");
    }

    // protected override void ResumeGame()
    public void ResumeGame()
    {
        // close inventory menu
        CloseMenu(Menu.InventoryMenu);
        // resume game
        Time.timeScale = 1f;
        Debug.Log("close inventory menu");
    }
}
