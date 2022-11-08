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
    [SerializeField]
    private WeaponRegistry registryToBeInitialized;
}


