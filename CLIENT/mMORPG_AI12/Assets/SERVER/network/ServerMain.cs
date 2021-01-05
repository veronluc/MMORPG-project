using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/// <summary>
/// The class that contains the main thread and that we use to start the server
/// </summary>
public class ServerMain : MonoBehaviour
{ 
    /// <summary>
    /// Boolean to know if the server is running
    /// </summary>
    private static bool isRunning = false;

    /// <summary>
    /// Method to start the server, the main thread and create the game server
    /// </summary>
    private void Start()
    {
        Console.WriteLine("Starting program...");
        isRunning = true;

        Thread mainThread = new Thread(new ThreadStart(MainThread));
        mainThread.Start();

        GameServer s = new GameServer();
        s.StartServer(50, 26950);
    }

    /// <summary>
    /// Create the main thread that lookup for new connections and messages
    /// </summary>
    private static void MainThread()
    {
        Console.WriteLine($"Main thread started. Running at {Constants.TICKS_PER_SEC} ticks per second.");
        DateTime _nextLoop = DateTime.Now;

        while (isRunning)
        {
            while (_nextLoop < DateTime.Now)
            {
                ThreadManager.UpdateMain();

                _nextLoop = _nextLoop.AddMilliseconds(Constants.MS_PER_TICK);

                if (_nextLoop > DateTime.Now)
                {
                    Thread.Sleep(_nextLoop - DateTime.Now);
                }
            }
        }
    }
}
