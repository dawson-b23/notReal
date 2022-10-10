using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MenuManager
{
    protected override void PauseGame()
    {
        // open pause menu
        OpenMenu(Menu.PauseMenu);
        // pause/stop game
        Time.timeScale = 0f;
        Debug.Log("open pause menu");
    }

    // protected override void ResumeGame()
    protected override void ResumeGame()
    {
        // close pause menu
        CloseMenu(Menu.PauseMenu);
        // resume game
        Time.timeScale = 1f;
        Debug.Log("close pause menu");
    }
}