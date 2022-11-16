/*
 * SkillTreeMenu.cs
 * Liam Mathews
 * Controls the UI that the player
 * interacts with when using the Skill Tree
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/*
 * SkillTreeMenu class
 * 
 * member variables:
 * pause - GameObject that holds the pause menu 
 * sk - instance of SkillTree class
 * DisplayNumber# - text variable for displaying each upgrade
 * count# - number of times an uprade function has been called
 * instance - instance of the SkillTreeMenu class
 * skillTreeUI - GameObject that holds the SkillTreeMenu subset
 *     of the Canvas in the hierarchy
 * Start() - creates instance of SkillTreeMenu if necessary,
 *     sets SkillTreeMenu to false, initializes TMP_Text for
 *     display 
 * MakeInactive() - set IsActive to false, closing the menu, calls
 *     calls AudioManager to play Main Game World music
 * MakeActive() - activate the menu when the IsActive is set to true
 *     calls AudioManager to play Skill Tree Menu music
 * IncreaseCount1() - On Click, check count and player.exp, call associated update
 *     function if conditions are met 
 * IncreaseCount2() - On Click, check count and player.exp, call associated update
 *     function if conditions are met 
 * IncreaseCount3() - On Click, check count and player.exp, call associated update
 *     function if conditions are met
 */
public class SkillTreeMenu : MonoBehaviour
{
    SkillTree sk = SkillTree.makeSkillTree();

    [SerializeField] GameObject pause;
    [SerializeField] GameObject skillTreeUI;

    public TMP_Text DisplayNumber1;
    public TMP_Text DisplayNumber2;
    public TMP_Text DisplayNumber3;
    public static SkillTreeMenu instance;

    private int count1;
    private int count2;
    private int count3;

    /* set skillTreeUI to inactive on startup
     * initialize display variables
     */
    public void Start()
    {
        //WIP Keeps track of number of instances of SkillTree
        /*
        if(instance != null){
            Debug.Log("Too many Skill Trees");
            Destroy(this);
        }

        if(instance == null){  
            instance = this;
            DontDestroyOnLoad(instance);
            Debug.Log("!");
        }
        */

        //Make SkillTreeMenu inactive when Scene starts
        skillTreeUI.SetActive(false);

        //Initialize values that are displayed on SkillTreeMenu
        DisplayNumber1.text = "LEVEL: " + count1.ToString() + "/5";
        DisplayNumber2.text = "LEVEL: " + count2.ToString() + "/5";
        DisplayNumber3.text = "LEVEL: " + count3.ToString() + "/5";

    }
    

    /* Resume the game, call AudioManager to play mainGame music
     */
    public void MakeInactive()
    {
        skillTreeUI.SetActive(false);

        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().PlayMusic("mainGame");

    }

    /* Check that pause menu is inactive, if not, set inactive
     * Pause game
     * Call AudioManager to play upgradeUI music 
     */
    public void MakeActive()
    {
        if(pause.activeSelf)
        {
            pause.SetActive(false);
        }

        skillTreeUI.SetActive(true);
        Time.timeScale = 0f;

        FindObjectOfType<AudioManager>().PlayMusic("upgradeUI");

        //AudioManager.instance.PlayMusic("upgradeUI");
        //AudioManager.instance.PlaySound("name_of_Sound");
        //IsActive = true;
    }

    /* Access Player variables
     * Check that count and player.exp are acceptable values
     * Iterate count
     * Upgrade the Player's attack value
     * Subtract the EXP by its cost
     * Call PlayerProfile, display new EXP value in HUD  
     */
    public void IncreaseCount1()
    {
        GameObject playerGameObject = GameObject.FindWithTag("Player");
        PlayerController player = playerGameObject.GetComponent<PlayerController>();

        if(count1 < 5 && player.exp >= 10)
        { 
            count1++;
            DisplayNumber1.text = "LEVEL: " + count1.ToString() + "/5"; 

            sk.updateAttack();

            player.exp -= 10;
            int newEXP = player.exp;

            FindObjectOfType<PlayerProfile>().updateEXP(-10);
                        
        }
    }

    /* Access Player variables
     * Check that count and player.exp are acceptable values
     * Iterate count
     * Upgrade the Player's health value
     * Subtract the EXP by its cost
     * Call PlayerProfile, display new EXP value in HUD  
     */
    public void IncreaseCount2()
    {
        GameObject playerGameObject = GameObject.FindWithTag("Player");
        PlayerController player = playerGameObject.GetComponent<PlayerController>();

        if(count2 < 5 && player.exp >= 10)
        {   
            count2++;
            DisplayNumber2.text = "LEVEL: " + count2.ToString() + "/5"; 
           
            sk.updateHealth();

            player.exp -= 10;
            FindObjectOfType<PlayerProfile>().updateEXP(-10);

            //In case we decide to do FullPlayerRestore when upgrading health
            //FindObjectOfType<PlayerProfile>().updateHealth(player.Maxhealth += (player.Maxhealth *= 0.15));
            //PlayerProfile.profileInstance.updateHealth(player.health += (player.health * 0.15));
        }
    }

    /* Access Player variables
     * Check that count and player.exp are acceptable values
     * Iterate count
     * Upgrade the Player's speed value
     * Subtract the EXP by its cost
     * Call PlayerProfile, display new EXP value in HUD  
     */
    public void IncreaseCount3()
    {
        GameObject playerGameObject = GameObject.FindWithTag("Player");
        PlayerController player = playerGameObject.GetComponent<PlayerController>();

        if(count3 < 5 && player.exp >= 10)
        {
            count3++;
            DisplayNumber3.text = "LEVEL: " + count3.ToString() + "/5"; 
        
            sk.updateMovement();
        
            player.exp -= 10;
            FindObjectOfType<PlayerProfile>().updateEXP(-10);
        
        }
    }
}
