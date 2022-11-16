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
    // reference to the timer
    Timer timerReference;

    /* 
     * function to open pause menu and pause game
     * overrides the function in MenuManager because this also opens the pause menu and stops the timer in addition to pausing the game
     * stops the timer on the HUD
     */
    // public  void pauseGame()
    public override void pauseGame()
    {
        // open pause menu
        openMenu(Menu.PauseMenu);
        // pause/stop game
        Time.timeScale = 0f;
        // pause timer
        timerReference.stopTimer();
        Debug.Log("open pause menu");
    }

    /* 
     * function to close pause menu and resume game
     * overrides the function in MenuManager because this also closes the pause menu and resumes the timer in addition to resuming the game
     */
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

    /*
     * opens the help menu
     * closes the pause menu
     */
    public void openHelp()
    {
        Debug.Log("Opening help menu");
        closeMenu(Menu.PauseMenu);
        openMenu(Menu.HelpMenu);
    }

    /*
     * closes the help menu
     * opens the pause menu
     */
    public void closeHelp()
    {
        Debug.Log("Closing help menu");
        closeMenu(Menu.HelpMenu);
        openMenu(Menu.PauseMenu);

    }

    /* 
     * if return to main menu button is clicked, load main menu scene
     * reset values
     */
    public void returnToMain()
    {
        resetValues();
        
        //Added by Bryan for errors
        LevelGeneration.hasLoaded = false;
        //

        SceneManager.LoadScene(0);
    }

    /*
     * reset values on HUD to zero
     */
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