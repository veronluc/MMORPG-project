using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InfoUserDisconnectedFromServer : Packet
{
    public override void Handle(Client c)
    {
        throw new NotImplementedException();
    }

    public override void Handle(GameServer s)
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
