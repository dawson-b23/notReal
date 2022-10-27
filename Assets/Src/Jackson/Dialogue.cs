using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Dialogue : MonoBehaviour
{
    //Fields
    //Indicator
    public GameObject indicator;
    //Window
    public GameObject window;
    //Dialogues List
    public List<string> dialogues;
    //character index;
    private int charIndex;
    //Index on dialogue
    private int index;
    //started boolean
    private bool started;
    //Text component
    public TMP_Text dialogueText;
    //Wait for next boolean
    private bool WaitForNext;
    //Writing speed 
    public float writingSpeed;



    private void Awake()
    {
        ToggleIndicator(false);
        ToggleWindow(false);
    }

    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }

    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }

    public void StartDialogue()
    {
        if (started)
            return;
        //Boolean to indicate we have started
        started = true;
        //show window
        ToggleWindow(true);
        //hide indicator
        ToggleIndicator(false);
        //Start first dialogue
        GetDialogue(0);
     
    }

    private void GetDialogue(int i)
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

    //End Dialogue
    public void EndDialogue()
    {
        //diable started and waitfornext
        started = false;
        WaitForNext = false;
        //stop all IENumerators
        StopAllCoroutines();
            //hide window
        ToggleWindow(false);
    }

    IEnumerator Writing()
    {
        
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
            WaitForNext = true;
        }
        

    }
    private void Update()
    {
            if (!started)
                return;
        if(WaitForNext && Input.GetKeyDown(KeyCode.E))
        {
            WaitForNext = false;
            index++;
            if(index < dialogues.Count)
            {
                GetDialogue(index);
            }
            else
            {
                ToggleIndicator(true);
                EndDialogue();
            }

        }
    }
}
