/**************************************
 * Jackson Baldwin - 11/2/2022        *
 * DemoModeRunner.cs - NotReal        *
 *                                    *
 * Plays demo video after             *
 * player has idled for an alloted    *
 * period of time                     *
 *                                    *
***************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoModeExampleScript : MonoBehaviour
{
    public GameObject videoPlayer;
    public GameObject menuHUD;
    public int idleTime;
    private int time = 0;
    

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

        if (!Input.anyKey && mouseMovement.magnitude == 0)
        {

            //Starts counting when no button is being pressed
            time++;
        }
        else
        {

            // If a button is being pressed restart counter to Zero and turn off video
            time = 0;
            videoPlayer.SetActive(false);
           // menuHUD.SetActive(true);
        }

        //if time equals idleTime,play the video
        if (time == idleTime)
        {
         videoPlayer.SetActive(true);
         menuHUD.SetActive(false);
        }

    }
}
