using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Item;

public class TestInventory : MonoBehaviour
{
    public List<Item> inventoryItems;

    // constructor initializes list
    public TestInventory()
    {
        inventoryItems = new List<Item>();
    }

    public Item CreateItem(ItemType itemtype)
    {
        Item item = new Item { itemType = itemtype, itemAmount = 1 };

        return item;
    }

    public void AddInventory(Item item)
    {
        inventoryItems.Add(item);
    }

    //public void RemoveInventory(Item item)
    public void RemoveInventory()
    {
        if (inventoryItems.Count > 0)
        {
            Item lastItem = inventoryItems.Last();
            inventoryItems.Remove(lastItem);
        }
    }

}
