using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // reference to the pause menu
    [SerializeField] GameObject pauseMenu;

    // function to open pause menu
    public void Open()
    {
        // open pause menu
        pauseMenu.SetActive(true);
        // pause game
        Time.timeScale = 0f;
        // call display available upgrades function?
    }

    // function to close pause menu and return to game
    public void Close()
    {
        // close pause menu
        pauseMenu.SetActive(false);
        // resume game
        Time.timeScale = 1f;
    }
}
