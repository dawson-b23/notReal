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
    private int totalHoney = 0, itemCost = 0;

    private GameObject playerObject;
    private Transform container;
    private Transform shopItemTemplate;



    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
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
      
        //first weapon
        string itemName = weapon[0].getDisplayName();
        Sprite itemSprite = weapon[0].gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
        CreateItemInShop(weapon[0], itemSprite, itemName, 0, 0);
        //second weapon
        string itemName2 = weapon[1].getDisplayName();
        Sprite itemSprite2 = weapon[1].gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
        CreateItemInShop(weapon[1], itemSprite2, itemName2, 0, 1);
        //third weapon
        string itemName3 = weapon[2].getDisplayName();
        Sprite itemSprite3 = weapon[2].gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
        CreateItemInShop(weapon[2], itemSprite3, itemName3, 0, 2);

        ToggleUI_Shop(false);
        
    }
    /*Creates an Instance of our ShopTemplate and populates it with the itemSprite, itemName, cost, and position for the UI.
    * The weapon itself is passed in to be sent to the shop
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
        
        itemCost = weapon.getPrice();
        
        if((itemCost <= totalHoney) && !Inventory.inventoryInstance.isFull())
        {
            playerObject.GetComponent<PlayerController>().removeHoney(itemCost);
            Inventory.inventoryInstance.addWeapon(weapon);
            Debug.Log("Bought an Item");
            //add item to user
        }
        else
        {
            Debug.Log("Error/insufficient funds");
            //display error
        }
    }
}
