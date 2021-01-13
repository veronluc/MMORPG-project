using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Thread manager for the server threads
/// </summary>
public class ThreadManager : MonoBehaviour
{
    /// <summary>
    /// List of actions to execute on the main thread
    /// </summary>
    private static readonly List<Action> executeOnMainThread = new List<Action>();
    /// <summary>
    /// Copie of the execute on main thread
    /// </summary>
    private static readonly List<Action> executeCopiedOnMainThread = new List<Action>();
    /// <summary>
    /// Current action to execute on main thread or not
    /// </summary>
    private static bool actionToExecuteOnMainThread = false;

    /// <summary>
    /// Update method for threads ==> Not used anymore, legacy only
    /// </summary>
    private void Update()
    {
        UpdateMain();
    }

    /// <summary>Sets an action to be executed on the main thread.</summary>
    /// <param name="_action">The action to be executed on the main thread.</param>
    public static void ExecuteOnMainThread(Action _action)
    {
        if (_action == null)
        {
            Debug.Log("No action to execute on main thread!");
            return;
        }

        lock (executeOnMainThread)
        {
            executeOnMainThread.Add(_action);
            actionToExecuteOnMainThread = true;
        }
    }

    /// <summary>Executes all code meant to run on the main thread. NOTE: Call this ONLY from the main thread.</summary>
    public static void UpdateMain()
    {
        if (actionToExecuteOnMainThread)
        {
            executeCopiedOnMainThread.Clear();
            lock (executeOnMainThread)
            {
                executeCopiedOnMainThread.AddRange(executeOnMainThread);
                executeOnMainThread.Clear();
                actionToExecuteOnMainThread = false;
            }

            for (int i = 0; i < executeCopiedOnMainThread.Count; i++)
            {
                executeCopiedOnMainThread[i]();
            }
        }
    }
}
