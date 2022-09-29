using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
        PlayerController player = GameObject.FindGameObjectWithTag("Player");
    
    private void Start(){

        //PlayerController player = GameObject.FindGameObjectWithTag("Player");
    }

    //public PlayerController playerController;

    int upgradeval = 5;
    int requiredexp = 10;


    void Upgrade(){
       if(player.exp >= requiredexp){
            player.speed += upgradeval;
            player.exp -= requiredexp;
    
            Debug.Log("exp = " + player.exp);
            Debug.Log("Upgrading");
        }else{

            Debug.Log("Not enough exp!");
        }
    
    }
    
}