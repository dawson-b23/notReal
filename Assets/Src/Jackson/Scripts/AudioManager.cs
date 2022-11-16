/*
 * Jackson Baldwin - 11/14/2022        
 * AudioManager.cs - NotReal        
 *                                    
 * Handles SFX and Music audio in the game
 * ...makes use of singleton pattern
 *                                    
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * AudioManager Class
 * Handles all audio within current game, including SFX and Music tracks
 * 
 * member variables:
 * instance - declaration of singleton
 * sfx_*, music_* - Declares all current SFX and Music tracks used by the game
 * currentMusicObject - Music that is currently being played
 * soundObject - links to Sound Prefab to create instance of any sound
 */
public class AudioManager : MonoBehaviour
{
    //declaration of singleton
    public static AudioManager instance;
    void Awake() { instance = this;  }

    //Sound Effects
    public AudioClip sfx_BC_Interact, sfx_boughtItem, sfx_errorBuyItem, sfx_meleeAttack, sfx_NPC_Interact, sfx_playerJump, sfx_rangedAttack;
    //Music Tracks
    public AudioClip music_mainMenu, music_mainGame, music_shopKeeper, music_upgradeUI;

    //Current Music Object
    public GameObject currentMusicObject;
    //Sound Object
    public GameObject soundObject;

    /* Works in partnership with soundObjectCreation() to play a VFX dependent on the string
     * Violates coding standards...should be playSFX(), but it is too late to change this...Many people's code already references the singleton,
     *so changing it now would break other's code.
     */ 
    public void PlaySFX(string sfxName)
    {
        switch(sfxName)
        {
            //cases for all current SFX (in alphabetical order)
            case "buyItem":
                soundObjectCreation(sfx_boughtItem);
                break;
            case "errorBuyItem":
                soundObjectCreation(sfx_errorBuyItem);
                break;
            case "interactBC":
                soundObjectCreation(sfx_BC_Interact);
                break;
            case "interactNPC":
                soundObjectCreation(sfx_NPC_Interact);
                break;
            case "meleeAttack":
                soundObjectCreation(sfx_meleeAttack);
                break;
            case "playerJump":
                soundObjectCreation(sfx_playerJump);
                break;
            case "rangedAttack":
                soundObjectCreation(sfx_rangedAttack);
                break;
            default:
                break;
        }
    }

    //creates SFX object with corresponding audio to key string
    void soundObjectCreation(AudioClip clip)
    {
        //Create SoundsObject gameobject
        GameObject newObject = Instantiate(soundObject, transform);
        //Assign audioclip to audiosource
        newObject.GetComponent<AudioSource>().clip = clip;
        //Play audio
        newObject.GetComponent<AudioSource>().Play();
    }




    /* Works in partnership with musicObjectCreation() to play a VFX dependent on the string
    * Violates coding standards...should be playMusic(), but it is too late to change this...Many people's code already references the singleton,
    *so changing it now would break other's code.
    */
    public void PlayMusic(string musicName)
    {
        switch (musicName)
        {
            //cases for all current music tracks (in alphabetical order)
            case "mainGame":
                musicObjectCreation(music_mainGame);
                break;
            case "mainMenu":
                musicObjectCreation(music_mainMenu);
                break;
            case "shopKeeper":
                musicObjectCreation(music_shopKeeper);
                break;
            case "upgradeUI":
                musicObjectCreation(music_upgradeUI);
                break;
            default:
                break;
        }
    }
    //creates music object with corresponding audio to key string
    void musicObjectCreation(AudioClip clip)
    {
        //Check for existing music object...if so delete
        if (currentMusicObject)
            Destroy(currentMusicObject);
        //Create SoundsObject gameobject
        currentMusicObject = Instantiate(soundObject, transform);
        //Assign audioclip to audiosource
        currentMusicObject.GetComponent<AudioSource>().clip = clip;
        //Loop the audio source
        currentMusicObject.GetComponent<AudioSource>().loop = true;
        //Play audio
        currentMusicObject.GetComponent<AudioSource>().Play();
    }
}
