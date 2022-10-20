using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StressInventory : MonoBehaviour
{
    public TextMeshProUGUI inventoryText;
    public int inventoryCount;
    public int addAmount = 1;
    public int maxAmount = 1;
    TestInventory testInventory = new TestInventory();

    // constructor initializes list
    public StressInventory()
    {
        if (testInventory.inventoryItems != null)
        {
            Debug.Log("list is not empty");
        }
        else
        {
            Debug.Log("list is empty");
        }
    }

    // make sure text is referenced
    public void Awake()
    {
        if (inventoryText != null)
        {
            Debug.Log("inventoryText != null");
        }
        else
        {
            Debug.Log("inventoryText is empty");
        }
    }

    public void Start()
    {
        StartCoroutine(UpdateInventory());
    }

    // stress test
    public IEnumerator UpdateInventory()
    {
        // loop: continue to add to inventory until a limit is reached
        for (int i = 0; i < maxAmount; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                for (int k = 0; k < 100; k++)
                {
                    for (int l = 0; l < 100; l++)
                    {
                        // create item
                        Item testItem = new Item { itemType = Item.ItemType.Melee, itemAmount = 1 };
                        // add item
                        testInventory.AddInventory(testItem);
                        inventoryText.text = "Inventory = " + testInventory.inventoryItems.Count;
                    }
                }
            }
            // update UI text 
            //inventoryText.text = "Inventory = " + testInventory.inventoryItems.Count;
            maxAmount++;
            yield return new WaitForSeconds(.00000000000000001f);
        }

        //Debug.Log("After test: inenvtory = " + testInventory.inventoryItems.Count);

        //yield return new WaitForSeconds(5f);
    }

}