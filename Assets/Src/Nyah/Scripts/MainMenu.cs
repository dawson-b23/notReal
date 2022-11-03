/*
 * MainMenu.cs
 * Nyah Nelson
 * Main Menu functions
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * MainMenu class to access features the main menu
 * 
 * member variables:
 * gameStartScene - value of start scene (can change in inspector)
 * startGame() - load first game scene
 * openOptions() - open options menu
 * closeOptions() - close options menu
 * quitGame() - quit the application
 */
public class MainMenu : MenuManager
{
    // scene to go to when starting the game
    // number in build settings
    // main menu = 0, first game room = 1
    [SerializeField] int gameStartScene;

    //Created by Jackson Baldwin (with permission from BC) to start the main menu theme...no changes are made to Nyah's code
    void Start()
    {
        AudioManager.instance.PlayMusic("mainMenu");
    }

    // load first game scene
    public void startGame()
    {
        SceneManager.LoadScene(gameStartScene);
        Debug.Log("Loading first level");
    }

    // open options menu
    public void openOptions()
    {
        Debug.Log("Opening Options menu");
        openMenu(Menu.OptionsMenu);
    }

    // close options menu
    public void closeOptions()
    {
        Debug.Log("Closing options menu");
        closeMenu(Menu.OptionsMenu);
    }

    // quit the application
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }

    public void openHelp()
    {
        Debug.Log("Opening help menu");
        openMenu(Menu.HelpMenu);
    }

    public void closeHelp()
    {
        Debug.Log("Closing help menu");
        closeMenu(Menu.HelpMenu);
    }
}
