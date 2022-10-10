using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MenuManager
{
    // scene to go to when starting the game
    // number in build settings
    // main menu = 0, first game room = 1
    public int gameStartScene;

    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);
        Debug.Log("Loading first level");
    }

    public void OpenOptions()
    {
        Debug.Log("Opening Options menu");
        OpenMenu(Menu.OptionsMenu);
    }

    public void CloseOptions()
    {
        Debug.Log("Closing options menu");
        CloseMenu(Menu.OptionsMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }
}
