using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    private PlayerController player = null;
    
    private void Start(){

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    //public PlayerController playerController;

    int upgradeval = 10;
    int requiredexp = 5;


    public void Upgrade(){
        Debug.Log("Current Exp: " + player.exp);
       if(player.exp >= requiredexp){
            player.PlayerSpeed += upgradeval;
            player.exp -= requiredexp;
    
            Debug.Log("exp = " + player.exp);
            Debug.Log("Upgrading");

            player.LevelUp();
        }else{

            Debug.Log("Not enough exp!");
        }
    
    }
    
}