/*
 * EndGameMenu.cs
 * Nyah Nelson
 * End Scene functions
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

/*
 * EndGameMenu class to display the Game Over Scene/Menu
 * 
 * member variables:
 * exitText, honeyText, timeText, levelText - references to the TMP objects
 * honeyValue , timeValue , levelValue - integer values for the display
 * playerObject - reference to the player controller script
 * 
 * member functions:
 * Start() - call functions to display ending scores
 * returnToMainMenu() - return to the main menu scene
 * updateExitText() - update the exit status
 * updateHoneyText() - update the honey value
 * updateTimeText() - update the time value
 * updateLevelText() - update the level value
 */
public class EndGameMenu : MenuManager
{
    public TextMeshProUGUI honeyText, timeText, levelText;
    private int honeyValue = 0, levelValue = 0;
    private float timeValue = 0;
    PlayerController playerObject;

    // main menu scene is scene 0 in build settings
    [SerializeField] int mainMenuScene;

    public void Start()
    {
        updateHoneyText();
        updateTimeText();
        updateLevelText();
    }

    public void returnToMainMenu()
    {
        resetValues();
        SceneManager.LoadScene(mainMenuScene);
    }

    public void updateHoneyText()
    {
        honeyValue = PlayerProfile.moneyValue;
        honeyText.text = "YOU COLLECTED " + honeyValue + " IN HONEY";
    }

    public void updateTimeText()
    {
        timeValue = Timer.currentTime;

        float minutes = Mathf.FloorToInt(timeValue / 60);
        float seconds = Mathf.FloorToInt(timeValue % 60);

        timeText.text = "YOUR TIME " + string.Format("{0:00} : {1:00}", minutes, seconds);
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

    public void resetValues()
    {
        // restart all values back to zero
        Timer.currentTime = 0f;
        PlayerProfile.moneyValue = 0;
        PlayerProfile.levelValue = 0;
        PlayerController.playerLevel = 0;
        PlayerProfile.healthValue = 0;
        PlayerProfile.inventoryValue = 0;
    }

}
