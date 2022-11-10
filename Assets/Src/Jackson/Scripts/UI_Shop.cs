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

    public void ToggleUI_Shop(bool show)
    {
        gameObject.SetActive(show);
    }

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        //Call Spencers code to populate the shop
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

    private void CreateItemInShop(AbstractWeapon weapon, Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 90f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("nameText").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("priceText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;

        //when clicked, try and purchase the weapon
        shopItemTransform.GetComponent<Button>().onClick.AddListener(() => TryBuyItem(weapon));
        
    }

    public void TryBuyItem(AbstractWeapon weapon)
    {

        Debug.Log("At least i got here");
        totalHoney = playerObject.GetComponent<PlayerController>().getHoney();
        Debug.Log("total honey is" + totalHoney);
        itemCost = 0; //weapon.getPrice();
        Debug.Log("Item cost is:" + itemCost);
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
