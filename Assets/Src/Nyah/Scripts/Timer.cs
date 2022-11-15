/*
 * Nyah Nelson
 * Timer.cs
 * timer display on the HUD functionality
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * Timer class has a reference to the TMP timer object and increments it, stops it, or resumes it
 * 
 * member variables:
 * TextMeshProUGUI timerText - object reference to the TMP object
 * float currentTime - current time from the start of the game
 * bool timerActive - bool to verify if the timer is active (counting) or not
 * 
 * member functions:
 * setTimerText() - display the correct time to the object
 * stopTimer() - set the bool to false so it stops counting
 * startTimer() - set the bool to true so it resumes counting
 */
public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    //[Header("Timer Settings")]
    public static float currentTime;

    private bool timerActive;

    // Start is called before the first frame update
    public void Start()
    {
        timerActive = true;

    }

    // Update is called once per frame
    // increment time
    public void Update()
    {
        if (timerActive)
        {
            currentTime += Time.deltaTime;
        }

        setTimerText();
    }

    /*
     * correctly display the time on the HUD using the TMP object reference
     */
    public void setTimerText()
    {
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = currentTime.ToString("0");
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    /*
     * change the active check to false to stop counting
     */
    public void stopTimer()
    {
        timerActive = false;
    }

    /*
     * change the active check to true to resume counting
     */
    public void startTimer()
    {
        timerActive = true;
    }
}
