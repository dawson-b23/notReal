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
    [SerializeField] GameObject pause;
    //AudioManager stMusic = new AudioManager();
    //SkillTree skilltree = GameObject.GetComponent<SkillTree>;

      public TMP_Text DisplayNumber1;
      public TMP_Text DisplayNumber2;
      public TMP_Text DisplayNumber3;

    private int count1;
    private int count2;
    private int count3;

    //public static bool IsActive = false;
    [SerializeField] GameObject skillTreeUI;

    public void Start(){
        skillTreeUI.SetActive(false);
        DisplayNumber1.text = "LEVEL: " + count1.ToString() + "/5";
        DisplayNumber2.text = "LEVEL: " + count2.ToString() + "/5";
        DisplayNumber3.text = "LEVEL: " + count3.ToString() + "/5";

    }
    

    //Resume game
    public void MakeInactive(){
        skillTreeUI.SetActive(false);
        Time.timeScale = 1f;
        //IsActive = false;
    }

    //pause game
    public void MakeActive(){
        if(pause.activeSelf){
            pause.SetActive(false);
        }

        skillTreeUI.SetActive(true);
        Time.timeScale = 0f;


        //FindObjectOfType<AudioManager>().PlayMusic("upgradeUI");

        //AudioManager.instance.PlayMusic("upgradeUI");
        //AudioManager.instance.PlaySound("name_of_Sound");
        //IsActive = true;
    }


    public void IncreaseCount1(){
        if(count1 < 5){
            count1++;
            DisplayNumber1.text = "LEVEL: " + count1.ToString() + "/5"; 
            //skilltree.updateAttack;
            //Debug.Log("count1: " + count1);
            
        }
    }

    public void IncreaseCount2(){
        if(count2 < 5){
            count2++;
            DisplayNumber2.text = "LEVEL: " + count2.ToString() + "/5"; 
            //Debug.Log("count2: " + count2);
        }
    }

    public void IncreaseCount3(){
        if(count3 < 5){
            count3++;
            DisplayNumber3.text = "LEVEL: " + count3.ToString() + "/5"; 
            //Debug.Log("count3: " + count3);
        }
    }
}
