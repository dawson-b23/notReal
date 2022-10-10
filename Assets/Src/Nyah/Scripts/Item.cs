using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public enum ItemType
    {
        Melee = 0,
        Gun = 1
    };

    public ItemType itemType;

    public int itemAmount;

    // public int maxInventory = 20;
}
