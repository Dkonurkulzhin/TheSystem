using System;
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

    protected MachineStatMessage() { }

    public MachineStatMessage(int index, bool isOccupied)
    {
        Index = index;
        IsOccupied = isOccupied;
    }

}

