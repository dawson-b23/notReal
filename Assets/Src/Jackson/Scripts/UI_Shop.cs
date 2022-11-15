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


public class UI_Shop : MonoBehaviour
{
    private int totalHoney = 0, itemShopPrice = 0;

    private GameObject playerObject;
    private Transform container;
    private Transform shopItemTemplate;
    private Transform itemImage;



    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
       // itemImage = transform.Find("itemImage");
    }

    //simple toggle method to be used from other scripts
    public void ToggleUI_Shop(bool show)
    {
        gameObject.SetActive(show);
    }

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
        CreateItemInShop(weapon[0], itemSprite, itemName, itemCost1, 0);
        //second weapon
        string itemName2 = weapon[1].getDisplayName();
        Sprite itemSprite2 = weapon[1].gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
        int itemCost2 = weapon[1].getPrice();
        CreateItemInShop(weapon[1], itemSprite2, itemName2, itemCost2, 1);
        //third weapon
        string itemName3 = weapon[2].getDisplayName();
        Sprite itemSprite3 = weapon[2].gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
        int itemCost3 = weapon[2].getPrice();
        CreateItemInShop(weapon[2], itemSprite3, itemName3, itemCost3, 2);

        string fullRestoreName = "Full Restore";
        //Sprite fullRestoreSprite = Resources.Load<Sprite>("Assets/Src/Jackson/Sprites/healthIcon.png");// gameObject.GetComponent<SpriteRenderer>().sprite;
        CreateHealthItemInShop(fullRestoreName, 100, 3);


        ToggleUI_Shop(false);
        
    }
    /*Creates an Instance of our ShopTemplate and populates it with the itemSprite, itemName, cost, and position for the UI.
    * The weapon itself is passed in to be sent to the shop...proxy (what is the object and what is the proxy to it)
    */
    private void CreateItemInShop(AbstractWeapon weapon, Sprite itemSprite, string itemName, int itemCost, int positionIndex)
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
        shopItemTransform.GetComponent<Button>().onClick.AddListener(() => TryBuyItem(weapon));
        
    }

    //Essentially the entire shop...very proud of how sleek this came out
    public void TryBuyItem(AbstractWeapon weapon)
    {

        
        totalHoney = playerObject.GetComponent<PlayerController>().getHoney();

        itemShopPrice = weapon.getPrice(); 

        //if the price is less than total player Honey (can afford the item), and player doesnt currently have a full inventory
            if ((itemShopPrice <= totalHoney) && !Inventory.inventoryInstance.isFull())
        {
            playerObject.GetComponent<PlayerController>().removeHoney(itemShopPrice);
            Inventory.inventoryInstance.addWeapon(weapon);
            //kaching!
            AudioManager.instance.PlaySFX("buyItem");
            Debug.Log("Bought an Item");
            //add item to user
        }
        else
        {
            Debug.Log("Error/insufficient funds");
            //beep beep
            AudioManager.instance.PlaySFX("errorBuyItem");
            
        }
    }
    /*Creates an Instance of our ShopTemplate and populates it with the itemSprite, itemName, cost, and position for the UI.
    * No weapon is sent in this instance, and ItemCost is set
    */
    private void CreateHealthItemInShop(string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        // Set the first Item in the shop and build the others below
        float shopItemHeight = 90f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("nameText").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("priceText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        //shopItemTransform.Find("itemImage").GetComponent<Image>().sprite; // = itemSprite;

        //when clicked, try and purchase the weapon
        shopItemTransform.GetComponent<Button>().onClick.AddListener(() => TryBuyHealth());
    }

    //very similar, nearly identical to TryBuyItem...uses static values instead of getting weapon prices...if health was made in a separate folder, this could be sleeker
    public void TryBuyHealth()
    {


        totalHoney = playerObject.GetComponent<PlayerController>().getHoney();

        itemShopPrice = 100; //set price for a full restore...100 gold

        //if the price is less than total player Honey (can afford the item), and player doesnt currently have full health
        //still working on this idea... if ((itemShopPrice <= totalHoney) && !(playerObject.GetComponent<PlayerController>().currentHealth() == playerObject.GetComponent<PlayerController>().effectiveMaxHealth()))
        if ((itemShopPrice <= totalHoney))
            {
                playerObject.GetComponent<PlayerController>().removeHoney(itemShopPrice);
                playerObject.GetComponent<PlayerController>().healFully();
                Debug.Log("Bought a Health Item");
                AudioManager.instance.PlaySFX("buyItem");
            //add item to user
        }
            else
            {
                Debug.Log("Error/insufficient funds");
            //display error
                AudioManager.instance.PlaySFX("errorBuyItem");
        }
    }
}
