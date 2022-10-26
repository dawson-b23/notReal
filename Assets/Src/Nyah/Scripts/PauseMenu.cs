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
 */
public class PauseMenu : MenuManager
{
    // function to open pause menu and pause game
    public void pauseGame()
    {
        // open pause menu
        openMenu(Menu.PauseMenu);
        // pause/stop game
        Time.timeScale = 0f;
        Debug.Log("open pause menu");
    }

    // protected override void ResumeGame()
    // function to close pause menu and resume game
    public void resumeGame()
    {
        // close pause menu
        closeMenu(Menu.PauseMenu);
        // resume game
        Time.timeScale = 1f;
        Debug.Log("close pause menu");
    }
}