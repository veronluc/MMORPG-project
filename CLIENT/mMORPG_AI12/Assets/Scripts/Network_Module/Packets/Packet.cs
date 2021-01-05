using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// The message namespace (packets)
/// </summary>
namespace Server.Network.Messages
{
    /// <summary>
    /// The master packet class (abstract)
    /// </summary>
    [Serializable]
    public abstract class Packet
    {
        /// <summary>
        /// Client side handle
        /// </summary>
        /// <param name="c">the client</param>
        public abstract void Handle(Client c);

        /// <summary>
        /// Server side handle
        /// </summary>
        /// <param name="s">The server</param>
        public  abstract void Handle(GameServer s);
    }
}
