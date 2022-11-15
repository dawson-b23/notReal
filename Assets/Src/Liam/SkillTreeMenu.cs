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
    SkillTree sk = SkillTree.makeSkillTree();

    //GameObject hudEXP = FindObjectOfType<PlayerProfile>();

      public TMP_Text DisplayNumber1;
      public TMP_Text DisplayNumber2;
      public TMP_Text DisplayNumber3;

    private int count1;
    private int count2;
    private int count3;

    public static SkillTreeMenu instance;

    //public static bool IsActive = false;
    [SerializeField] GameObject skillTreeUI;


    //public void resetSkillTree(){
    //    instance = instance.reset();
    //}

    public void Start(){
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
        //Add EXP requirement
        GameObject playerGameObject = GameObject.FindWithTag("Player");
        PlayerController player = playerGameObject.GetComponent<PlayerController>();
        
        //player.currenthealth = player.currenthealth;

        //Debug.Log("=============  " + player.exp);
        if(count1 < 5 && player.exp >= 10){ 
            count1++;
            DisplayNumber1.text = "LEVEL: " + count1.ToString() + "/5"; 
            sk.updateAttack();

            //Debug.Log("Before UPGRADE ===============: " + player.exp);

            player.exp -= 10;
            
            int newEXP = player.exp;

            FindObjectOfType<PlayerProfile>().updateEXP(-10);
            
            //Debug.Log("After UPGRADE ===============: " + player.exp);
            
        }
    }

    public void IncreaseCount2(){
        GameObject playerGameObject = GameObject.FindWithTag("Player");
        PlayerController player = playerGameObject.GetComponent<PlayerController>();
        
        if(count2 < 5 && player.exp >= 10){
           
            count2++;
           
            DisplayNumber2.text = "LEVEL: " + count2.ToString() + "/5"; 
           
            sk.updateHealth();

            player.exp -= 10;
           
            FindObjectOfType<PlayerProfile>().updateEXP(-10);
            //FindObjectOfType<PlayerProfile>().updateHealth(player.Maxhealth += (player.Maxhealth *= 0.15));
            //PlayerProfile.profileInstance.updateHealth(player.health += (player.health * 0.15));
            //Debug.Log("count2: " + count2);
        }
    }

    public void IncreaseCount3(){
        GameObject playerGameObject = GameObject.FindWithTag("Player");
        PlayerController player = playerGameObject.GetComponent<PlayerController>();
        if(count3 < 5 && player.exp >= 10){
            count3++;
            DisplayNumber3.text = "LEVEL: " + count3.ToString() + "/5"; 
            sk.updateMovement();
            player.exp -= 10;
            FindObjectOfType<PlayerProfile>().updateEXP(-10);
            //Debug.Log("count3: " + count3);
        }
    }
}
