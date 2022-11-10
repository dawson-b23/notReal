/*
 * RegistryInitializer.cs
 * Spencer Butler
 * A script that holds a reference to a WeaponRegistry
 */


using UnityEngine;


/*
 * Holds a reference to a WeaponRegistry
 *
 * Unity will not call OnEnable/Awake on ScriptableObjects without a GameObject that references them
 * This references one, so its OnEnable method will be called
 *
 * member variables:
 * registryToBeInitialized - the registry to be initialized
 */
public class RegistryInitializer : MonoBehaviour
{
    //ScriptableAsset's built in enable/awake methods are dicey in terms of when they get called
    //Having a reference to an asset on a gameobject means the enable method will be called when the scene is loaded
    [SerializeField]
    private WeaponRegistry registryToBeInitialized;
}


