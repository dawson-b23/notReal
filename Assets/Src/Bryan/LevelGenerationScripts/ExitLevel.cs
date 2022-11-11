using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
  /*
    OnTriggerEnter2D()
    Detects when object with tag "Player" collides with the object and reloads the current scene
  */
 private void OnTriggerEnter2D(Collider2D col){
    Debug.Log("collided");

    if(col.CompareTag("Player")){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // adds 1 to playerLevel everytime a world is completed
        PlayerController.playerLevel += 1;

        /* added by Nyah Nelson
         * update the player profile level value on the HUD
         */
        PlayerProfile.profileInstance.updateLevel(1);
        /*
         * Added by Nyah Nelson
         * makes sure that the same HUD will be on every scene with the same time, weapons, honey
         */
         DontDestroyOnLoad(GameObject.Find("HUD"));
    }
 
  }
   
}
