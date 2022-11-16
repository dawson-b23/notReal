/**************************************
 * Jackson Baldwin - 11/9/2022        *
 * UI_Shop.cs - NotReal               *
 *                                    *
 * Shop and UI for the ShopKeeper     *   
 * Builds a shop from 3 random weapons*
 * and includes one healing item      *
***************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
 * UI_Shop Class
 * Handles dynamic construction of shop, as well as purchasing of shop items
 * 
 * member variables:
 * playerObject - connects to player to get totalHoney, currentHoney, etc
 * container - Transform GameObject that connects to the container within the shopItemTemplate prefab
 * itemImage - Transform GameObject that connects to the itemImage prefab
 * shopItemTemplate - Transform GameObject that connects to the shopItemTemplate itself
 * ...all 3 GameObjects here use Transform to change as shop is created
 * itemShopPrice - private int that sets prices of items within the shop...used in the tryBuy functions
 * totalHoney - private int that is set to players current Honey
 */
public class UI_Shop : MonoBehaviour
{
    private GameObject playerObject;

    private Transform container;
    private Transform itemImage;
    private Transform shopItemTemplate;

    private int itemShopPrice = 0, totalHoney = 0;

    //on Awake, connect Transforms to appropriate GameObjects
    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    //simple toggle method to be used from other scripts
    public void toggleUI_Shop(bool show)
    {
        gameObject.SetActive(show);
    }

    //Populates the shop with 3 random items from the Shop and one Full Restore...calls createItem and createHealthItem 
    private void Start()
    {
        //find our player...need to reference current honey
        playerObject = GameObject.FindGameObjectWithTag("Player");


        //Call Spencers code to populate the shop...getting an array of 3 weapons
        AbstractWeapon[] weapon = WeaponRegistry.getWeaponRegistry().getWeapons(3);
      
        //first weapon...get item's name, correct sprite, and associated cost
        string itemName = weapon[0].getDisplayName();
        Sprite itemSprite = weapon[0].gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
        int itemCost1 = weapon[0].getPrice();
        createItemInShop(weapon[0], itemSprite, itemName, itemCost1, 0);
        //second weapon
        string itemName2 = weapon[1].getDisplayName();
        Sprite itemSprite2 = weapon[1].gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
        int itemCost2 = weapon[1].getPrice();
        createItemInShop(weapon[1], itemSprite2, itemName2, itemCost2, 1);
        //third weapon
        string itemName3 = weapon[2].getDisplayName();
        Sprite itemSprite3 = weapon[2].gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
        int itemCost3 = weapon[2].getPrice();
        createItemInShop(weapon[2], itemSprite3, itemName3, itemCost3, 2);

        string fullRestoreName = "Full Restore";
        //Does not take in a sprite...Full Restore Sprite is set to default
        createHealthItemInShop(fullRestoreName, 100, 3);


        toggleUI_Shop(false);
        
    }

    /*Creates an Instance of our ShopTemplate and populates it with the itemSprite, itemName, cost, and position for the UI.
    * The weapon itself is passed in to be sent to the shop...proxy (what is the object and what is the proxy to it)
    */
    private void createItemInShop(AbstractWeapon weapon, Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        // Set the first Item in the shop and build the others below
        float shopItemHeight = 90f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("nameText").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("priceText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;

        //when clicked, try and purchase the weapon
        shopItemTransform.GetComponent<Button>().onClick.AddListener(() => tryBuyItem(weapon));
        
    }

    //Essentially the entire shop...very proud of how sleek this came out
    public void tryBuyItem(AbstractWeapon weapon)
    {

        
        totalHoney = playerObject.GetComponent<PlayerController>().getHoney();

        itemShopPrice = weapon.getPrice(); 

        //if the price is less than total player Honey (can afford the item), and player doesnt currently have a full inventory
            if ((itemShopPrice <= totalHoney) && !Inventory.inventoryInstance.isFull())
        {
            playerObject.GetComponent<PlayerController>().removeHoney(itemShopPrice);
            //add item to user
            Inventory.inventoryInstance.addWeapon(weapon);
            //kaching! sound effect played when an item is successfully purchased (instance of audio manager)
            AudioManager.instance.PlaySFX("buyItem");
            Debug.Log("Bought an Item");
        }
        else
        {
            Debug.Log("Error/insufficient funds");
            //beep beep error sound effect if player doesn't have inventory/doesn't have enough funds (instance of audio manager)
            AudioManager.instance.PlaySFX("errorBuyItem");
            
        }
    }

    /*Creates an Instance of our ShopTemplate and populates it with the itemName, cost, and position for the UI.
    * No weapon is sent in this instance, and ItemCost is set. No sprite is passed in to keep the default sprite
    */
    private void createHealthItemInShop(string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        // Set the first Item in the shop and build the others below
        float shopItemHeight = 90f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("nameText").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("priceText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        //when clicked, try and purchase the weapon
        shopItemTransform.GetComponent<Button>().onClick.AddListener(() => tryBuyHealth());
    }

    //very similar, nearly identical to TryBuyItem...uses static values instead of getting weapon prices...if health was made in a separate folder, this could be sleeker
    public void tryBuyHealth()
    {
        totalHoney = playerObject.GetComponent<PlayerController>().getHoney();

        itemShopPrice = 100; //set price for a full restore...100 gold

        //if the price is less than total player Honey (can afford the item), and player doesnt currently have full health
        //still working on this idea... if ((itemShopPrice <= totalHoney) && !(playerObject.GetComponent<PlayerController>().currentHealth() == playerObject.GetComponent<PlayerController>().effectiveMaxHealth()))
        if ((itemShopPrice <= totalHoney))
        {
            //remove cost of Item from player's current Honey
            playerObject.GetComponent<PlayerController>().removeHoney(itemShopPrice);
            //heal player fully
            playerObject.GetComponent<PlayerController>().healFully();
            Debug.Log("Bought a Health Item");
            //play kaching! sound effect when item is successfully purchased (instance of audio manager)
            AudioManager.instance.PlaySFX("buyItem");
        }
        else
        {
            Debug.Log("Error/insufficient funds");
            //play error sound effect when player does not have enough funds or health is already full (instance of audio manager)
            AudioManager.instance.PlaySFX("errorBuyItem");
        }
    }
}
