/**************************************
 * Jackson Baldwin - 11/2/2022        *
 * SetDialogue.cs - NotReal           *
 *                                    *
 * Prefab to handle dialogue boxes    *
 * for unique NPCS...dealt            *
 * to handle scripted, static dialogue*
 * between an NPC and the user        *   
 *                                    *
***************************************/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
 * SetDialogue Class
 * used by specific friendly NPC prefabs
 * to create and visually implement modular, set dialogue
 * 
 * member variables:
 * uiShop - added to turn on the shop afer text has been recieved. Only works if shop is connected to this prefab
 * ...that way, QueenBC will not trigger the Shop
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
public class SetDialogue : MonoBehaviour
{
    //Fields
    [SerializeField] private UI_Shop uiShop;
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

    //when Dialogue starts, turn off the indicator, show the window, and start the first setDialogue
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
        //Start first dialogue
        getDialogue(0);
        //call instance of audio manager when first dialogue string is read
        AudioManager.instance.PlaySFX("interactBC");

    }

    //resets appropriate variables and begins writing selected string
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

    //End Dialogue and hide the window
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
    //if 'E' is pressed, check if writing has started. Keep calling getDialogue and Writing until the List is empty. Then, endDialogue().
    private void Update()
    {
            if (!started)
                return;
        if(waitForNext && Input.GetKeyDown(KeyCode.E))
        {
            waitForNext = false;
            index++;
            if(index < dialogues.Count)
            {
                getDialogue(index);
                //call instance of audio manager every time a new dialogue box is made. This way, BC will continue to buzz as she talks
                //interact BC should really be called "interactSetNPC", because the same sound is played for shopKeeper
                AudioManager.instance.PlaySFX("interactBC");
            }
            else
            {
                toggleIndicator(true);
                endDialogue();
                //turn on shop after the end of dialogue...only applies to shopKeeeper
                uiShop.toggleUI_Shop(true);
            }

        }
    }
}
