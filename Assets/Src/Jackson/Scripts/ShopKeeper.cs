using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{

    [SerializeField] private UI_Shop uiShop;

    public randomDialogue dialogueScript;

    private bool playerInRange;

    private void OnTriggerEnter2D(Collider2D other)
    {
          if(other.CompareTag("Player"))
          {
            playerInRange = true;
            dialogueScript.ToggleIndicator(playerInRange);
          }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
          if(other.CompareTag("Player"))
          {
            playerInRange = false;
            dialogueScript.ToggleIndicator(playerInRange);
            dialogueScript.EndDialogue();
            uiShop.ToggleUI_Shop(false);
        }
    }

    private void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            dialogueScript.StartDialogue();
        }

    }
}
