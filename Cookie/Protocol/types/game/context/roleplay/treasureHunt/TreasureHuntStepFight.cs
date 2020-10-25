using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class TreasureHuntStepFight : TreasureHuntStep
    {
        public new const short ProtocolId = 462;
        public override short TypeId { get { return ProtocolId; } }

        public TreasureHuntStepFight(): base()
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
        }

        public override void Deserialize(ICustomDataInput reader)
        {
        }
    }
}