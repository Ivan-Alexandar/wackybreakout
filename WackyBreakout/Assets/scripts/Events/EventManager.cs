using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An event manager
/// </summary>
public static class EventManager
{
    #region Fields
    // I kind of get this how this code works. Makes a list of invokers from the PickupBlock class and a list
    // of listeners for the freezer effect event
    static List<PickupBlock> freezerEffectInvokers = new List<PickupBlock>();
    static List<UnityAction<float>> freezerEffectListeners = new List<UnityAction<float>>();

    static List<PickupBlock> speedUpEffectInvokers = new List<PickupBlock>();
    static List<UnityAction<float, float>> speedUpEffectListeners = new List<UnityAction<float, float>>();
    

    #endregion

    #region Methods
    // I maybe get this. Makes a method for adding invokers to the invoker list.
    // Adds a listner to all the invokers :).
    public static void AddFreezerEffectInvoker(PickupBlock invoker)
    {
        //adds the specified invoker to the list of invokers
        freezerEffectInvokers.Add(invoker);
        //I kind of get this
        foreach  (UnityAction<float> listener in freezerEffectListeners)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }
    // I should get this. Makes a method that adds listners to the list of listeners. 
    // Adds a listener to all the invokers :)))).
    public static void AddFreezerEffectListener(UnityAction<float> listener)
    {
        //adds the specified invoker to the list of invokers
        freezerEffectListeners.Add(listener);
        // I fucking get this 
        foreach (PickupBlock invoker in freezerEffectInvokers)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }
    //^^^^^^^ The two foreach loops are made it doesn't matter what method is called first :)). ^^^^^^^^^


    public static void AddSpeedUpEffectInvoker(PickupBlock invoker)
    {
        speedUpEffectInvokers.Add(invoker);
        foreach (UnityAction<float,float> listener in speedUpEffectListeners)
        {
            invoker.AddSpeedUpEffectListener(listener);
        }
    }
    public static void AddSpeedUpEffectListener(UnityAction<float,float> listener)
    {
        speedUpEffectListeners.Add(listener);
        foreach (PickupBlock invoker in speedUpEffectInvokers)
        {
            invoker.AddSpeedUpEffectListener(listener);
        }
    }


    #endregion
}
