/*
 * MainMenu.cs
 * Nyah Nelson
 * Main Menu functions
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/*
 * MainMenu class to access features the main menu
 * 
 * member variables:
 * gameStartScene - value of start scene (can change in inspector)
 * 
 * member functions:
 * Start() - play the audio at the beginning of the frame 
 * startGame() - load first game scene
 * openOptions() - open options menu
 * closeOptions() - close options menu
 * openHelp() - open help menu
 * closeHelp() - close help menu
 * quitGame() - quit the application
 */
public class MainMenu : MenuManager
{
    // scene to go to when starting the game
    // number in build settings
    // main menu = 0, first game room = 1
    [SerializeField] int gameStartScene;


    //Created by Jackson Baldwin (with permission from BC) to start the main menu theme...no changes are made to Nyah's code
    /*
     * plays the background music (Jackson's feature)
     * destroys the HUD Game Object if it is active
     * destroys the skill tree menu instance
     */
    void Start()
    {
        AudioManager.instance.PlayMusic("mainMenu");

        if (GameObject.Find("HUD").activeSelf)
        {
            Destroy(GameObject.Find("HUD"));
        }

        if (GameObject.Find("Canvas").activeSelf)
        {
            Destroy(GameObject.Find("Canvas"));
        }
    }

    /* 
     * this function will be called when the start button on the Main Menu is clicked
     * this function loads the first game scene which is a serialized field variable
     * the variable gameStartScene is able to be changed in the inspector 
     * gameStartScene is set to 1 in the prefab, so the scene in the build settings numbered 1 will be loaded 
     */
    public void startGame()
    {
        SceneManager.LoadScene(gameStartScene);
        if (Time.timeScale == 0f)
        {
            resumeGame();
        }
    }

    /*
     * this function will be called when the options button on the Main Menu game object is clicked on 
     * this function opens the options menu that is associated with the Options Menu game object in the inspector of the Main Menu object
     * this function uses the inherited function openMenu from the MenuManager class
     * the openMenu function activates (opens) the options menu game object
     */
    public void openOptions()
    {
        openMenu(Menu.OptionsMenu);
    }

    /*
     * this function will be called when the close button on the Options Menu game object is clicked on 
     * this function closes the options menu that is associated with the Options Menu game object in the inspector of the Main Menu object
     * this function uses the inherited function closeMenu from the MenuManager class
     * the closeMenu function deactivates (closes) the options menu game object
     */
    public void closeOptions()
    {
        closeMenu(Menu.OptionsMenu);
    }

    /*
     * this function will be called when the quit button on the Main Menu game object is clicked on
     * this function quits the player application (shuts the game down)
     */
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game...");
    }

    /*
    * this function will be called when the help button on the Main Menu game object is clicked on
    * this function open the help menu that is associated with the Help Menu game object in the inspector of the Main Menu object
    * this function uses the inherited function openMenu from the MenuManager class
    * the openMenu function activates (opens) the help menu game object
    */
    public void openHelp()
    {
        openMenu(Menu.HelpMenu);
    }

    /*
    * this function will be called when the close button on the Help Menu game object is clicked on 
    * this function closes the help menu that is associated with the Help Menu game object in the inspector of the Main Menu object
    * this function uses the inherited function closeMenu from the MenuManager class
    * the closeMenu function deactivates (closes) the help menu game object
    */
    public void closeHelp()
    {
        closeMenu(Menu.HelpMenu);
    }

    /*
     * copyright component: the main menu is a derivative work based upon the original work (stranger things logo)
     * downloaded the font online, and imported it to the assets folder
     * i had to create a text mesh pro asset of the font in order to use it (right click on the font -> create -> text mesh pro -> font asset)
     * argument:
     * The legal implication is that the original owner can declare this as a derivative of their work, and therefore is considered copyright. 
     * They could sue me for the profits (if I were to make any off of this feature). However, this is not considered an infringement of of copyright 
     * because, under the law of fair use, the amount and substantiality of the portion used in relation to the copyrighted work as a whole. 
     * Im using a limited amount of the work, so it is not an infringement of copyright. It is also not that big of a part of the game, it is not considered 
     * the “heart” of the game, so it isn’t that big of a deal, and is protected under fair use. 
     */
}

