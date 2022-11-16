/**************************************
 * Jackson Baldwin - 11/2/2022        *
 * DemoModeVideoRunner.cs - NotReal   *
 *                                    *
 * Plays demo video after             *
 * player has idled for an alloted    *
 * period of time                     *
 *                                    *
***************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * DemoModeVideoRunner Class
 * Plays demo video after player has idled for an alloted period of time.
 * 
 * member variables:
 * menuHud - GameObject reference to Nyah's HUD on main menu
 * videoPlayer - GameObject reference to videoPlayer itself
 * idleTime - public int changeable by user...use to indicate how long we want to idle before playing the Demo
 * time - private integer not seen by user...used to increment time in the "Idle" state
 */
public class DemoModeVideoRunner : MonoBehaviour
{
    //GameObject references to videoPlayer and menuHUD
    public GameObject menuHUD;
    public GameObject videoPlayer;

    //idle time is public so we can modify how long it takes for the DemoMode to appear
    public int idleTime;
    private int time = 0;
    
    //turns on videoPlayer on main menu. If a player clicks or moves the mouse, it will instantly go away
    void Start()
    {
        videoPlayer.SetActive(true);
        menuHUD.SetActive(false);
    }

    //Use fixed update because its called every fixed framerate frame
    void FixedUpdate()
    {
        //to detect mouse movement
        Vector2 mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        //if no input has been pressed and no movement is detected from mouse, begin to increment time
        if (!Input.anyKey && mouseMovement.magnitude == 0)
        {
            time++;
        }
        else
        {
            // If a button is being pressed, restart counter to Zero and turn off video
            time = 0;
            videoPlayer.SetActive(false);
           // menuHUD.SetActive(true);
        }

        //if time equals idleTime, play the video
        if (time == idleTime)
        {
         videoPlayer.SetActive(true);
         menuHUD.SetActive(false);
        }

    }
}
