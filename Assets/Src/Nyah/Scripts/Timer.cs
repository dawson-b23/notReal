using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;

    private bool timerActive;

    // Start is called before the first frame update
    void Start()
    {
        timerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            currentTime += Time.deltaTime;
        }

        setTimerText();
    }

    public void setTimerText()
    {
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = currentTime.ToString("0");
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
            //currentTime.ToString("0");
    }

    public void stopTimer()
    {
        timerActive = false;
    }

    public void startTimer()
    {
        timerActive = true;
    }
}
