/*
 * SkillTreeManager.cs
 * Liam Mathews
 * == WORK IN PROGRESS == 
 * Maintains instance of Skill Tree
 * between rooms in-game, resets Skill Tree
 * once back in Main Menu 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
 * SkillTreeManager class
 * 
 * member variables:
 * instance - instance of SkillTreeManager class
 * Awake() - checks if an instance of the Skill Tree
 *     exists and if current scene is MainMenu, 
 *     creates one if not   
 */
public class SkillTreeManager : MonoBehaviour
{
    /*
    public static SkillTreeManager instance;

    // Start is called before the first frame update
    private void Awake()
    {
        //Scene currentScene = 
        Scene scene = SceneManager.GetActiveScene();

        //if(scene.name != "MainMenu"){
            
        //}

            if(instance == null){
                instance = this;
                //Debug.Log("There's too many SkillTreeUI's!");
                DontDestroyOnLoad(this);
            }else{
                Debug.Log("There's too many SkillTreeUI's!");
                Destroy(this.gameObject);
                //instance = null;
            }

            //if(scene.name == "MainMenu"){
            //      Destroy(this.gameObject);
            //      Debug.Log("Yo Mr White we're removing a skill tree!");
            //      instance = null;
            //}
    } */
}
