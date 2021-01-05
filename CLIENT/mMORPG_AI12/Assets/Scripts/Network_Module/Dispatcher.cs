using System.Collections.Generic;
using System.Threading;
using System;
using UnityEngine;

/// <summary>
/// The Thread dispacher for the client
/// </summary>
public class Dispatcher : MonoBehaviour
{
    /// <summary>
    /// Not used anymore
    /// </summary>
    /// <param name="action"></param>
    public static void RunAsync(Action action)
    {
        ThreadPool.QueueUserWorkItem(o => action());
    }

    /// <summary>
    /// Not used anymore
    /// </summary>
    /// <param name="action"></param>
    /// <param name="state"></param>
    public static void RunAsync(Action<object> action, object state)
    {
        ThreadPool.QueueUserWorkItem(o => action(o), state);
    }

    /// <summary>
    /// To run on main thread
    /// </summary>
    /// <param name="action"></param>
    public static void RunOnMainThread(Action action)
    {
        lock (_backlog)
        {
            _backlog.Add(action);
            _queued = true;
        }
    }

    /// <summary>
    /// Not used anymore
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        if (_instance == null)
        {
            _instance = new GameObject("Dispatcher").AddComponent<Dispatcher>();
            DontDestroyOnLoad(_instance.gameObject);
        }
    }

    /// <summary>
    /// Not used anymore
    /// </summary>
    private void Update()
    {
        if (_queued)
        {
            lock (_backlog)
            {
                var tmp = _actions;
                _actions = _backlog;
                _backlog = tmp;
                _queued = false;
            }

            foreach (var action in _actions)
                action();

            _actions.Clear();
        }
    }

    static Dispatcher _instance;
    static volatile bool _queued = false;
    static List<Action> _backlog = new List<Action>(8);
    static List<Action> _actions = new List<Action>(8);
}