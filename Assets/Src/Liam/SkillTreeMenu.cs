/*
 * SkillTreeMenu.cs
 * Liam Mathews
 * Controls the UI that the player
 * interacts with when using the Skill Tree
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    //public static bool IsActive = false;
    [SerializeField] GameObject skillTreeUI;

    void Start(){
        skillTreeUI.SetActive(false);
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
        skillTreeUI.SetActive(true);
        Time.timeScale = 0f;
        //IsActive = true;
    }
}
