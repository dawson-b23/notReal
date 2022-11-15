/*
 * HUDManager.cs
 * Nyah Nelson
 * HUD manager to make sure that the instance of the HUD is not destroyed
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * HUDManager class that will be attached to the HUD component and make sure that the entire instance of the HUD is not destroyed
 * 
 * member variables:
 * HUDManager instance - singleton for the HUDManager
 * 
 */
public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;

    private void Awake()
    {
        // thread safe singleton check
        if (instance == null)
        {
            instance = this;
            // do not destroy this instance when a new scene is reloaded
            DontDestroyOnLoad(this);
        }
        else
        {
            // extra instance so destroy this instance
            Debug.Log("error: extra HUDManager instance");
            Destroy(this.gameObject);
        }
    }
}
