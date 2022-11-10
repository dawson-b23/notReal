using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_Shop : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;


    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        ToggleUI_Shop(false);
    }

    public void ToggleUI_Shop(bool show)
    {
        shopItemTemplate.gameObject.SetActive(show);
    }

    private void Start()
    {
        //Call Spencers code to populate the shop
        AbstractWeapon[] weapon = WeaponRegistry.getWeaponRegistry().getWeapons(3);

        //AbstractWeapon weapon = WeaponRegistry.getWeaponRegistry().getWeapon();

        //string itemName = weapon.getDisplayName();
        //Sprite itemSprite = weapon.gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
        //CreateItemInShop(itemSprite, itemName, 0, 0);

        //CreateItemInShop(itemSprite, "You're mom", 0, 1);
        //CreateItemInShop(itemSprite, "Your mam", 0, 2);
        //CreateItemInShop(itemSprite, " you ARE mom", 0, 3);
        
        //first weapon
        string itemName = weapon[0].getDisplayName();
        Sprite itemSprite = weapon[0].gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
        CreateItemInShop(itemSprite, itemName, 0, 0);
        //second weapon
        string itemName2 = weapon[1].getDisplayName();
        Sprite itemSprite2 = weapon[1].gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
        CreateItemInShop(itemSprite2, itemName2, 0, 1);
        //third weapon
        string itemName3 = weapon[2].getDisplayName();
        Sprite itemSprite3 = weapon[2].gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
        CreateItemInShop(itemSprite3, itemName3, 0, 2);
        
    }

    private void CreateItemInShop(Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 90f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("nameText").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("priceText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;
    }
}
