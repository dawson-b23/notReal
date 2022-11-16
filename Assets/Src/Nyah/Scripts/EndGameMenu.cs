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
    // reference to TMP objects, public so can access in inspector 
    public TextMeshProUGUI honeyText, timeText, expText;

    private int honeyValue = 0, endEXPValue = 0;
    private float timeValue = 0;
    PlayerController playerObject;

    // main menu scene is scene 0 in build settings
    [SerializeField] int mainMenuScene;

    private void Awake()
    {
        Destroy(GameObject.Find("HUD"));
    }

    public void Start()
    {
        updateHoneyText();
        updateTimeText();
        updateEXPText();
    }

    /*
     * resets all values displayed on the HUD and loads the main menu scene
     * called when the return to main menu button is clicked
     */
    public void returnToMainMenu()
    {
        resetValues();
        
        //Added by Bryan for errors
        LevelGeneration.hasLoaded = false;
        //

        SceneManager.LoadScene(mainMenuScene);
    }

    /*
     * displays the final honey value on the game over scene
     */
    public void updateHoneyText()
    {
        honeyValue = PlayerProfile.moneyValue;
        honeyText.text = "YOU COLLECTED " + honeyValue + " IN HONEY";
    }

    /*
     * displays the final time on the game over scene
     */
    public void updateTimeText()
    {
        timeValue = Timer.currentTime;

        float minutes = Mathf.FloorToInt(timeValue / 60);
        float seconds = Mathf.FloorToInt(timeValue % 60);

        timeText.text = "YOUR TIME: " + string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    /*
     * displays the final EXP value
     */
    public void updateEXPText()
    {
        endEXPValue = PlayerProfile.expValue;
        expText.text = "YOUR EXP: " + endEXPValue;
    }

    /*
     * resets all values on the HUD to zero
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
