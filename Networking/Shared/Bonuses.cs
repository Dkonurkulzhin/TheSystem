using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

[ProtoContract]

public class BonusObject
{
    [ProtoMember(1)]
    public int startHour;
    [ProtoMember(2)]
    public int endHour;
    [ProtoMember(3)]
    public int cost;
    [ProtoMember(4)]
    public string bonusName;
    [ProtoMember(5)]
    public int bonusID;
    [ProtoMember(6)]
    public int startDay;
    [ProtoMember(7)]
    public float feeMultiplier;

    protected BonusObject() {}

    public BonusObject(int BonusID, string BonusName, int StartHour, int EndHour, int Cost, float FeeMultiplier)
    {
        startHour = StartHour;
        endHour = EndHour;
        cost = Cost;
        bonusName = BonusName;
        bonusID = BonusID;
        feeMultiplier = FeeMultiplier;
    }

}


