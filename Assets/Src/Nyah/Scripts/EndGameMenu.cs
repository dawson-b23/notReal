using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameMenu : MenuManager
{
    public TextMeshProUGUI exitText, honeyText, timeText;
    private int honeyValue = 0, timeValue = 0; 
    PlayerController playerObject;

    // main menu scene is scene 0 in build settings
    [SerializeField] int mainMenuScene;

    public void returnToMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void updateExitText()
    {
        // if the user exited the hive (how to tell if this is true)
        exitText.text = "YOU EXITED THE HIVE!";
        // else the user did not exit the hive
        //exitText.text = "YOU DIDN'T EXIT THE HIVE!";
    }

    public void updateHoneyText()
    {
        honeyValue = playerObject.GetComponent<PlayerController>().getLifetimeHoney();
        honeyText.text = "YOU COLLECTED " + honeyValue + " IN HONEY";
    }

    public void updateTimeText()
    {
        // timeValue = get time value somehow
        timeText.text = "YOUR TIME " + timeValue;
    }


}
