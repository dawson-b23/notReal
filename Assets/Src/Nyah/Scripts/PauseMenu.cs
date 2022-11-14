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
 * member functions:
 * pauseGame() - open pause menu and pause game
 * resumeGame() - close pause menu and resume game
 * openHelp() - open help menu
 * closeHelp() - close help menu
 * returnToMain() - return to main menu scene
 */
public class PauseMenu : MenuManager
{
    Timer timerReference;
    // function to open pause menu and pause game
    // public  void pauseGame()
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
        // pause timer
        timerReference.stopTimer();
        Debug.Log("open pause menu");
    }

    // function to close pause menu and resume game
    //public void resumeGame()
    public override void resumeGame()
    {
        // close pause menu
        closeMenu(Menu.PauseMenu);
        // resume game
        Time.timeScale = 1f;
        // resume timer
        timerReference.startTimer();
        Debug.Log("close pause menu");
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
        resetValues();
        SceneManager.LoadScene(0);
    }

    public void resetValues()
    {
        // restart all values back to zero
        Timer.currentTime = 0f;
        PlayerProfile.moneyValue = 0;
        PlayerProfile.expValue = 0;
        PlayerController.playerLevel = 0;
        PlayerProfile.healthValue = 0;
        Inventory.inventoryInstance.weaponList.Clear();
    }
}