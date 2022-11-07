/*
 * PauseMenu.cs
 * Nyah Nelson
 * Pause menu features
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * PauseMenu class to open/close menu and pause/resume game
 * 
 * member variables:
 * pauseGame() - open pause menu and pause game
 * resumeGame() - close pause menu and resume game
 * openInventory() - open inventory menu, close pause game menu
 * returnToMain() - return to main menu scene
 */
public class PauseMenu : MenuManager
{
    // function to open pause menu and pause game
    public override void pauseGame()
    {
        // if the skill tree menu is open, close it before opening the pause menu
        /*if (skillTreeMenu.activeSelf)
        {
            closeMenu(Menu.SkillTreeMenu);
        }*/
        // open pause menu
        openMenu(Menu.PauseMenu);
        // pause/stop game
        Time.timeScale = 0f;
        Debug.Log("open pause menu");
    }

    // protected override void ResumeGame()
    // function to close pause menu and resume game
    public override void resumeGame()
    {
        // close pause menu
        closeMenu(Menu.PauseMenu);
        // resume game
        Time.timeScale = 1f;
        Debug.Log("close pause menu");
    }

    // add inventory stuff

    // if inventory button is clicked open inventory
    public void openInventory()
    {
        closeMenu(Menu.PauseMenu);
        openMenu(Menu.InventoryMenu);

    }

    public void openHelp()
    {
        Debug.Log("Opening help menu");
        closeMenu(Menu.PauseMenu);
        openMenu(Menu.HelpMenu);
    }

    public void closeHelp()
    {
        Debug.Log("Closing help menu");
        closeMenu(Menu.HelpMenu);
        openMenu(Menu.PauseMenu);

    }

    // if return to main menu button is clicked, load main menu scene
    public void returnToMain()
    {
        SceneManager.LoadScene(0);
    }
}