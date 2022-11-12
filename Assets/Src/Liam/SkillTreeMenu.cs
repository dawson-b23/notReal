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
 * IsActive - boolean value that checks if the menu is active
 * Update() - Unity function, called once per frame
 * MakeInactive() - set IsActive to false, closing the menu
 * MakeActive() - activate the menu when the IsActive is set to true
 */
public class SkillTreeMenu : MonoBehaviour
{
    public TMP_Text DisplayNumber1;
      public TMP_Text DisplayNumber2;
      public TMP_Text DisplayNumber3;

    private int count1;
    private int count2;
    private int count3;

    /*
     * Added By Nyah Nelson
     * object reference to the pause menu
     */
    public GameObject pauseMenu;

    //public static bool IsActive = false;
    [SerializeField] GameObject skillTreeUI;

    void Start(){
        skillTreeUI.SetActive(false);
        DisplayNumber1.text = "LEVEL: " + count1.ToString() + "/5";
        DisplayNumber2.text = "LEVEL: " + count2.ToString() + "/5";
        DisplayNumber3.text = "LEVEL: " + count3.ToString() + "/5";

    }
    // Update is called once per frame
    /*
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            if(IsActive){
                MakeInactive();
            }else{
                MakeActive();
            }

        }
    }*/

    //Resume game
    public void MakeInactive(){
        skillTreeUI.SetActive(false);
        Time.timeScale = 1f;
        //IsActive = false;
    }

    //pause game
    public void MakeActive(){
        /*
         * added by Nyah Nelson
         * checks if the pause menu is open when the skill tree button is clicked
         * then closes the pause menu before the skill tree menu is opened
         */
        // if the pause menu is open, close it before opening the skill tree menu
        if (pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
        }
        skillTreeUI.SetActive(true);
        Time.timeScale = 0f;
        //IsActive = true;
    }

    public void IncreaseCount1(){
        if(count1 < 5){
            count1++;
            DisplayNumber1.text = "LEVEL: " + count1.ToString() + "/5"; 
            Debug.Log("count1: " + count1);
            
        }
    }

    public void IncreaseCount2(){
        if(count2 < 5){
            count2++;
            DisplayNumber2.text = "LEVEL: " + count2.ToString() + "/5"; 
            Debug.Log("count2: " + count2);
        }
    }

    public void IncreaseCount3(){
        if(count3 < 5){
            count3++;
            DisplayNumber3.text = "LEVEL: " + count3.ToString() + "/5"; 
            Debug.Log("count3: " + count3);
        }
    }
}
