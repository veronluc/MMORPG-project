using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ServerMain : MonoBehaviour
{ 
    private static bool isRunning = false;
    private void Start()
    {
        Debug.Log("Starting program...");
        isRunning = true;

        Thread mainThread = new Thread(new ThreadStart(MainThread));
        mainThread.Start();

        GameServer s = new GameServer();
        s.StartServer(50, 26950);
    }
    private static void MainThread()
    {
        Debug.Log($"Main thread started. Running at {Constants.TICKS_PER_SEC} ticks per second.");
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
