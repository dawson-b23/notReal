/*
 *  Activity.cs
 *  Dawson Burgess
 *  Logic for creating scriptable activity objects
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  This is a scriptable object in order to reduce memory consumption by resuing 
 *  the same piece of data. This is not ideal for functionality, so we will make it
 *  abstract to implement it using methods by child classes.
 *
 *  member functions
 *  
 *  Enter()   - Enter the activity 
 *  Execute() - Execute the activity
 *  Exit()    - Exit the activity 
 */

/*
 *  The Builder design pattern separates the construction of a complex object from its 
 *  representation so that the same construction process can create different representations.
 *
 *  Builder  (VehicleBuilder)
        specifies an abstract interface for creating parts of a Product object
    
    ConcreteBuilder  (MotorCycleBuilder, CarBuilder, ScooterBuilder)
        constructs and assembles parts of the product by implementing the Builder interface
        defines and keeps track of the representation it creates
        provides an interface for retrieving the product
    
    Director  (Shop)
        constructs an object using the Builder interface
    
    Product  (Vehicle)
        represents the complex object under construction. ConcreteBuilder builds the product's 
            internal representation and defines the process by which it's assembled

        includes classes that define the constituent parts, including interfaces for assembling 
            the parts into the final result
 */
namespace AI.FSM
{
    public abstract class Activity : ScriptableObject
    {
        public abstract void Enter(BaseStateMachine stateMachine);

        public abstract void Execute(BaseStateMachine stateMachine);

        public abstract void Exit(BaseStateMachine stateMachine);
    }
}