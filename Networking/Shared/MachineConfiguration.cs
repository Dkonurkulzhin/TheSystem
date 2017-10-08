using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

[ProtoContract]

public class MachineConfiguration
{
        [ProtoMember(1)]
        public string MachineLabel;
        [ProtoMember(2)]
        public float PriceMultiplier;
        

        protected MachineConfiguration() { }

        public MachineConfiguration(string machineLabel, float priceMultiplier = 1)
        {
            MachineLabel = machineLabel;
            PriceMultiplier = priceMultiplier;
        }
            
}

