/*ExitLevel.cs
Bryan Frahm
A script attached to an exit that reloads the scene
Also keeps track of amountNavigated for EnemySpawner.cs
as well as hasLoaded
*/

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
  public static int amountNavigated;
 private void OnTriggerEnter2D(Collider2D col){
    Debug.Log("collided");

    if(col.CompareTag("Player")){
         LevelGeneration.hasLoaded = false;
          amountNavigated = amountNavigated + 1;
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // adds 1 to playerLevel everytime a world is completed
       // PlayerController.playerLevel += 1;
       

    
    }
 
  }
   
}
