/*
 * Jackson Baldwin - 11/09/2022        
 * KillSound.cs - NotReal        
 *                                    
 * Script that works in conjunction with
 * AudioManager.cs...kills GameObject after 
 * audio is done playing                                   
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * KillSound Class
 * used by AudioManager to kill GameObjects after audio is done playing
 * 
 * member variables:
 * source - AudioSource GameObject that is currently playing sound
 */
public class KillSound : MonoBehaviour
{
    AudioSource source;

    void Start()
    {
        //check for current Audio Source
        source = GetComponent<AudioSource>();
    }


    void Update()
    {
        //once current Audio source is no longer playing, kill it
        if(!source.isPlaying)
        {
            //Debug.Log(name + " Stopped Playing");
            Destroy(gameObject);
        }
    }
}
