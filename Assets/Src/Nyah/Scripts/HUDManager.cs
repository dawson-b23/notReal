using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.Log("error: extra HUDManager instance");
            Destroy(this.gameObject);
        }

        Debug.Log("there are " + Inventory.inventoryInstance.inventoryAmount() + " weapons in inventory");
        for (int i = 0; i < 3; i++)
        {
            if (Inventory.inventoryInstance.slots[i] == null)
            {
                Debug.Log("there is nothing in slots[" + i + "]");
            }
        }
    }
}
