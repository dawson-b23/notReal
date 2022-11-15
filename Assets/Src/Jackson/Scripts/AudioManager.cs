using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //singleton
    public static AudioManager instance;
    void Awake() { instance = this;  }

    //Sound Effects
    public AudioClip sfx_BC_Interact, sfx_getXP, sfx_meleeAttack, sfx_NPC_Interact, sfx_playerJump, sfx_rangedAttack;
    //Music Tracks
    public AudioClip music_mainMenu, music_mainGame, music_shopKeeper, music_upgradeUI;
    //Current Music Object
    public GameObject currentMusicObject;

    //Sound Object
    public GameObject soundObject;


    public void PlaySFX(string sfxName)
    {
        switch(sfxName)
        {
            case "getXP":
                SoundObjectCreation(sfx_getXP);
                break;
            case "meleeAttack":
                SoundObjectCreation(sfx_meleeAttack);
                break;
            case "rangedAttack":
                SoundObjectCreation(sfx_rangedAttack);
                break;
            case "playerJump":
                SoundObjectCreation(sfx_playerJump);
                break;
            case "interactNPC":
                SoundObjectCreation(sfx_NPC_Interact);
                break;
            case "interactBC":
                SoundObjectCreation(sfx_BC_Interact);
                break;
            default:
                break;
        }
    }

    void SoundObjectCreation(AudioClip clip)
    {
        //Create SoundsObject gameobject
        GameObject newObject = Instantiate(soundObject, transform);
        //Assign audioclip to audiosource
        newObject.GetComponent<AudioSource>().clip = clip;
        //Play audio
        newObject.GetComponent<AudioSource>().Play();
    }

    public void PlayMusic(string musicName)
    {
        switch (musicName)
        {
            case "mainMenu":
                MusicObjectCreation(music_mainMenu);
            case "mainMusic":
                MusicObjectCreation(music_mainGame);
                break;
            case "shopKeeper":
                MusicObjectCreation(music_shopKeeper);
                break;
            case "upgradeUI":
                MusicObjectCreation(music_upgradeUI);
                break;
            
            default:
                break;
        }
    }

    void MusicObjectCreation(AudioClip clip)
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
