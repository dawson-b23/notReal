/*
 * Observer.cs
 * Nyah Nelson
 * Base class for the observers
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Observer abstract base class to declare abstract functions and protected variables inherited by subclasses
 * 
 * member variables:
 * inventory - protected variable reference to Inventory (subject of the observers)
 * 
 * member functions:
 * fullUpdate() - method called when inventory is full; will have a different definition in each of the observer sub classes 
 * notFullUpdate() - method called when inventory is not full; will have a different definition in each of the observer sub classes
 */
public abstract class Observer
{
    // protected means the object can only be accessed by this class and the derived classes 
    protected Inventory inventory;

    /* abstract keyword allows for members to be incomplete (not declared)
     * but must be implemented in sub classes 
     */
    public abstract void fullUpdate();
    public abstract void notFullUpdate();
}
