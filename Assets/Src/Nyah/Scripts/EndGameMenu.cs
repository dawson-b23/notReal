using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameMenu : MenuManager
{
    public TextMeshProUGUI exitText, honeyText, timeText, levelText;
    private int honeyValue = 0, timeValue = 0, levelValue = 0; 
    PlayerController playerObject;

    // main menu scene is scene 0 in build settings
    [SerializeField] int mainMenuScene;

    public void Start()
    {
        updateExitText();
        updateHoneyText();
        updateTimeText();
        updateLevelText();

    }

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

    public void updateLevelText()
    {
        levelValue = PlayerController.playerLevel;
        if (levelValue == 1)
        {
            levelText.text = "YOU MADE IT THROUGH " + levelValue + " LEVEL";
        }
        else
        {
            levelText.text = "YOU MADE IT THROUGH " + levelValue + " LEVELS";
        }
    }

}
