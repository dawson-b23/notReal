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
 * the observer "listens" to updates (notifications) from the subject class (inventory) and all the subclasses of the observer will change based on the notification
 * disadvantage: observers are notified at random
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
    // type inventory because inventory is the subject (the one notifying the observers)
    protected Inventory inventory;

    /* abstract keyword allows for members to be incomplete (not declared)
     * but must be implemented in sub classes 
     */
    public abstract void fullUpdate();
    public abstract void notFullUpdate();

    /*
     * why i chose the observer pattern:
     * i chose the observer because i wanted to be able to notify multiple classes when the inventory was full. I did both the UI and inventory,
     * so I wanted them to complement eachother by having the UI change when inentory was full or not full. I created three observer classes to change 
     * when inventory became full.
     * 
     * the mediator pattern could be used to complete something similar with less coupling. mediator is more specific
     * observers are notified at random
     * observer is one to many, so don't use it if you have many to many 
     */
}
