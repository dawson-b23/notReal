using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using static UnityEditor.Progress;

// arrange all preconditions and inputs
// act on the method under the test
// assert occurence of expected results

// VALIDATE that inventory updates correctly
// VERIFY that you can't add an item if inventory is full

public class InventoryTests
{
    [Test]

    // adding to inventory in range
    public void AddInRangeTest()
    {
        // ARRANGE
        var inventory = new Inventory();
        var expectedAmount = 1;

        // ACT
        var item = new Item { itemType = Item.ItemType.Melee, itemAmount = 1 };
        inventory.AddInventory(item);

        // ASSERT
        Assert.That(inventory.ItemCount(), Is.EqualTo(expectedAmount));
    } 

    // adding to inventory above range
    public void AddAboveRangeTest()
    {
        // ARRANGE
        var inventory = new Inventory();
        var expectedAmount = 1;
        // change what the maximum amount allowed for inventory is 
        inventory.maxInventory = 1;

        // ACT
        // add one item to make it the max inventory value
        var item1 = new Item { itemType = Item.ItemType.Melee, itemAmount = 1 };
        inventory.AddInventory(item1);
        // add another to test
        var item2 = new Item { itemType = Item.ItemType.Melee, itemAmount = 1 };
        inventory.AddInventory(item2);

        // ASSERT
        // how to check to see if i get a certain debug message? 
        Assert.That(inventory.ItemCount(), Is.EqualTo(expectedAmount));
    } 
    
    // removing from inventory below range
    public void RemoveBelowRangeTest()
    {
        // ARRANGE
        var inventory = new Inventory();
        var expectedAmount = 0;
        // change what the maximum amount allowed for inventory is

        // ACT
        // add one item to make it the max inventory value
        var item1 = new Item { itemType = Item.ItemType.Melee, itemAmount = 1 };
        inventory.RemoveInventory(item1);

        // ASSERT
        // how to check to see if i get a certain debug message? 
        Assert.That(inventory.ItemCount(), Is.EqualTo(expectedAmount));
    }
}
