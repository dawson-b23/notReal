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

    int upgradeval = 5;
    int requiredexp = 10;


    void Upgrade(){
       if(player.exp >= requiredexp){
            player.playerSpeed += upgradeval;
            player.exp -= requiredexp;
    
            Debug.Log("exp = " + player.exp);
            Debug.Log("Upgrading");
        }else{

            Debug.Log("Not enough exp!");
        }
    
    }
    
}