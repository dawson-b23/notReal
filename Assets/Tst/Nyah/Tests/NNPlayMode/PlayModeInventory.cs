using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine.UI;
using TMPro;
using static Item;
using System.Threading;
using System;

public class PlayModeInventory : MonoBehaviour
{
    Inventory testInventory = new Inventory();

    public void Start()
    {
        //add ten items to inventory (inventory half full)
        for (int i = 0; i < 10; i++)
        {
            Item testItem = new Item { itemType = Item.ItemType.Melee, itemAmount = 1 };
            testInventory.inventoryItems.Add(testItem);
        }
        Debug.Log("count: " + testInventory.inventoryItems.Count);

        /*StartCoroutine(AddToInventory());
        StartCoroutine(RemoveFromInventory());*/

        int count = 0;
        while (count < 12)
        {
            StartCoroutine(InventoryTest());
        }

        // test works if inventory is 10 after adding and removing
        Assert.That(testInventory.inventoryItems.Count == 10);
      
    }

    public void Update()
    {
        
    }

    [UnityTest]
    //public IEnumerator AddToInventory([ValueSource("testInventory")] Inventory inventory)
    public IEnumerator InventoryTest()
    {
        for (int i = 0; i < 10; i++)
        {
            Item testItem = new Item { itemType = Item.ItemType.Melee, itemAmount = 1 };
            testInventory.inventoryItems.Add(testItem);
        }
        Debug.Log("count: " + testInventory.inventoryItems.Count);

        int count = 0;

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.5f);

            Thread t1 = new Thread(() => AddTo(count));
            Thread t2 = new Thread(() => RemoveFrom(count));

            t1.Start();
            t2.Start();
        
            Assert.That(testInventory.inventoryItems.Count == 10);
            count++;

            t1.Abort();
            t2.Abort();
        }
    }

    public void AddTo(int count)
    {
        Debug.Log("in AddToInventory");
        Debug.Log("count: " + testInventory.inventoryItems.Count);

        for (int i = 0; i < count; i++)
        {
            Item testItem = new Item { itemType = Item.ItemType.Melee, itemAmount = 1 };
            testInventory.AddInventory(testItem);
            Debug.Log("Adding " + i);
        }
    }

    public void RemoveFrom(int count)
    {
        Debug.Log("in RemoveFromInventory");
        Debug.Log("count: " + testInventory.inventoryItems.Count);

        for (int i = 0; i < count; i++)
        {
            testInventory.RemoveInventory();
            Debug.Log("Removing " + i);
        }

    }

}
