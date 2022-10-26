/*
 * InventoryTests.cs
 * Nyah Nelson
 * Boundary tests for inventory
 */
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using static UnityEditor.Progress;

// arrange all preconditions and inputs
// act on the method under the test
// assert occurence of expected results

// VALIDATE that inventory updates correctly
// VERIFY that you can't add an item if inventory is full

/*
 * InventoryTests class to test inventory functions
 * 
 * member variables:
 * AddInRangeTest() - test in range
 * AddAboveRangeTest() - test above range
 * RemoveBelowRangeTest() - test below range
 */
public class InventoryTests
{
    [Test]

    // adding to inventory in range
    public void AddInRangeTest()
    {
        // ARRANGE
        var inventory = new InventoryList();
        var expectedAmount = 1;

        // ACT
        var item = new Item { itemAmount = 1 };
        inventory.AddInventory(item);

        // ASSERT
        //Assert.That(inventory.ItemCount(), Is.EqualTo(expectedAmount));
        Assert.That(inventory.inventoryItems.Count, Is.EqualTo(expectedAmount));
    }

    [Test]

    // adding to inventory above range
    public void AddAboveRangeTest()
    {
        // ARRANGE
        var inventory = new InventoryList();
        var expectedAmount = 1;
        // change what the maximum amount allowed for inventory is 
        inventory.maxInventory = 1;

        // ACT
        // add one item to make it the max inventory value
        var item1 = new Item { itemAmount = 1 };
        inventory.AddInventory(item1);
        // add another to test
        var item2 = new Item { itemAmount = 1 };
        inventory.AddInventory(item2);

        // ASSERT
        // how to check to see if i get a certain debug message? 
        //Assert.That(inventory.ItemCount(), Is.EqualTo(expectedAmount));
        Assert.That(inventory.inventoryItems.Count, Is.EqualTo(expectedAmount));

    }

    [Test]

    // removing from inventory below range
    public void RemoveBelowRangeTest()
    {
        // ARRANGE
        var inventory = new InventoryList();
        var expectedAmount = 0;
        // change what the maximum amount allowed for inventory is

        // ACT
        // add one item to make it the max inventory value
        //var item1 = new Item { itemType = Item.ItemType.Melee, itemAmount = 1 };
        inventory.RemoveInventory();

        // ASSERT
        // how to check to see if i get a certain debug message? 
        //Assert.That(inventory.ItemCount(), Is.EqualTo(expectedAmount));
        Assert.That(inventory.inventoryItems.Count, Is.EqualTo(expectedAmount));
    }
}
