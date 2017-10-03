﻿using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;
[ProtoContract]
public class MachineStatMessage
{
    [ProtoMember(1)]
    public int Index;

    [ProtoMember(2)]
    public bool IsOccupied;

    [ProtoMember(3)]
    public string Username;

    [ProtoMember(4)]
    public long Balance;

    [ProtoMember(5)]
    public long MinutesLeft;

    [ProtoMember(6)]
    public long ClientVersion;

    protected MachineStatMessage() { }

    public MachineStatMessage(int index, bool isOccupied, string username, 
        long balance, long minutesLeft, long clientVersion)
    {
        Index = index;
        IsOccupied = isOccupied;
        Username = username;
        Balance = balance;
        MinutesLeft = minutesLeft;
        ClientVersion = clientVersion;
    }

}

