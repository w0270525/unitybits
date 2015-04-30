#region CreatedBy

// Created by Jonathan Prince
// 04292015

#endregion

using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    //Notification manager listener. this is rather than using a 2d array.
    private Dictionary<string, List<Component>> listeners = new Dictionary<string, List<Component>>();

    /// <summary>
    ///     Function to add a listener for an notification to the listeners list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="notificationName"></param>
    public void AddListener(Component sender, string notificationName)
    {
        //Add listener to dictionary
        if (!listeners.ContainsKey(notificationName))
            listeners.Add(notificationName, new List<Component>());

        //Add object to listener list for this notification
        listeners[notificationName].Add(sender);
    }

    /// <summary>
    ///     Function to remove a listener for a notification
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="notificationName"></param>
    public void RemoveListener(Component sender, string notificationName)
    {
        //If no key in dictionary exists, then exit
        if (!listeners.ContainsKey(notificationName))
            return;

        //Cycle through listeners and identify component, and then remove
        for (int i = listeners[notificationName].Count - 1; i >= 0; i--)
        {
            //Check instance ID
            if (listeners[notificationName][i].GetInstanceID() == sender.GetInstanceID())
                listeners[notificationName].RemoveAt(i); //Matched. Remove from list
        }
    }

    /// <summary>
    ///     Function to post a notification to a listener
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="notificationName"></param>
    public void PostNotification(Component sender, string notificationName)
    {
        //If no key in dictionary exists, then exit
        if (!listeners.ContainsKey(notificationName))
            return;

        //Else post notification to all matching listeners
        foreach (var listener in listeners[notificationName])
            listener.SendMessage(notificationName, sender, SendMessageOptions.DontRequireReceiver);
    }

    /// <summary>
    ///     Function to clear all listeners.
    /// </summary>
    public void ClearListeners()
    {
        //Removes all listeners
        listeners.Clear();
    }

    /// <summary>
    ///     Function to remove redundant listeners.
    /// </summary>
    public void RemoveRedundancies()
    {
        //Create new dictionary
        var tmpListeners = new Dictionary<string, List<Component>>();

        //Cycle through all dictionary entries
        foreach (var item in listeners)
        {
            //Cycle through all listener objects in list, remove null objects
            for (var i = item.Value.Count - 1; i >= 0; i--)
            {
                //If null, then remove item
                if (item.Value[i] == null)
                    item.Value.RemoveAt(i);
            }

            //If items remain in list for this notification, then add this to tmp dictionary
            if (item.Value.Count > 0)
                tmpListeners.Add(item.Key, item.Value);
        }

        //Replace listeners object with new, optimized dictionary
        listeners = tmpListeners;
    }

    /// <summary>
    ///     Called when new level was loaded. kind of useless.
    /// </summary>
    private void OnLevelWasLoaded()
    {
        RemoveRedundancies();
    }
}