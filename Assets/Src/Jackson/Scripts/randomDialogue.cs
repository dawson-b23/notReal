/**************************************
 * Jackson Baldwin - 11/2/2022        *
 * RandomDialogue.cs - NotReal        *
 *                                    *
 * Prefab to handle dialogue boxes    *
 * for NPC's...updated to randomize   *
 * dialogue                           *
 *                                    *
***************************************/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
 * RandomDialogue Class
 * used by non-specific friendly NPC prefabs
 * to create and visually implement random dialogue
 * 
 * member variables:
 * indicator - GameObject that connects to indicator in prefab
 * window - GameObject that connects to the TextMeshPro window
 * dialogues - public list of dialogue options for the RandomDialogue to spit out
 * dialogueText - public type TextMeshPro that connects to the text component itself
 * writingSpeed - public variable that sets the speed of text
 * charIndex - private index that increments through the dialogue script
 * index - index that increments through the list of dialogues
 * started - boolean to know we have started writing
 * waitForNext - boolean to know we
 */
public class RandomDialogue : MonoBehaviour
{
    //Fields
    //Indicator
    public GameObject indicator;
    //Window
    public GameObject window;

    //Dialogues List
    public List<string> dialogues;
    //Text component
    public TMP_Text dialogueText;
    //Writing speed 
    public float writingSpeed;

    //character index;
    private int charIndex;
    //Index on dialogue
    private int index;
    //started boolean
    private bool started;
    //Wait for next boolean
    private bool waitForNext;
    


    //makes sure indicator and window are both not active on Awake
    private void Awake()
    {
        toggleIndicator(false);
        toggleWindow(false);
    }

    //essentially a boolean to toggle Window on and off
    private void toggleWindow(bool show)
    {
        window.SetActive(show);
    }

    //essentially a boolean to toggle Indicator on and off
    public void toggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }

    //when Dialogue starts, turn off the indicator, show the window, and select a randomDialogue
    public void startDialogue()
    {
        if (started)
            return;
        //Boolean to indicate we have started
        started = true;
        //show window
        toggleWindow(true);
        //hide indicator
        toggleIndicator(false);
        //Start a random dialogue (from 26 options)...area for improvement here
        int randNum = Random.Range(0, 25);
        getDialogue(randNum);
        //instance of Audio Manager...play interactNPC sound effect when dialogue begins
        AudioManager.instance.PlaySFX("interactNPC");

    }

    //resets appropriate variables and begins writing selected string (by randNum)
    private void getDialogue(int i)
    {

        //start index at zero
        index = i;
        //reset character index
        charIndex = 0;
        //clear the dialogue component text
        dialogueText.text = string.Empty;
        //start writing
        StartCoroutine(Writing());
    }

    //End dialogue and hide the window
    public void endDialogue()
    {
        //diable started and waitfornext
        started = false;
        waitForNext = false;
        //stop all IENumerators
        StopAllCoroutines();
        //hide window
        toggleWindow(false);
    }

    //Writing component...not in camelCase because its only one word
    IEnumerator Writing()
    {
        //sets current dialogue to selected dialogue within List
        string currentDialogue = dialogues[index];
        //write the character
        dialogueText.text += currentDialogue[charIndex];
        //increase character index
        charIndex++;
        //ensure you are at end of sentence
        if (charIndex < currentDialogue.Length)
        {
            //wait and restart
            yield return new WaitForSeconds(writingSpeed);
            StartCoroutine(Writing());
        }
        else
        {
            waitForNext = true;
        }
        

    }

    //if 'E' is pressed again, end Dialogue...because all RandomDialogues are only one string long
    private void Update()
    {
            if (!started)
                return;
        if(waitForNext && Input.GetKeyDown(KeyCode.E))
        {
            waitForNext = false;
            index++;
            toggleIndicator(true);
            endDialogue();
        }
    }
}
