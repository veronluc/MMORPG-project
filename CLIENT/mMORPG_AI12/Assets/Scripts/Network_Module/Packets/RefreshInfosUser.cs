using AI12_DataObjects;
using Server.Network.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class RefreshInfosUser : Packet
{
    User NewUserInfos;
    public RefreshInfosUser(User pNewUserInfos)
    {
        NewUserInfos = pNewUserInfos;
    }
    public override void Handle(Client c)
    {
        throw new System.NotImplementedException();
    }

    public override void Handle(GameServer s)
    {
        s.data.UserRefreshInfos(NewUserInfos);
    }
}
