using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class TreasureHuntStepDig : TreasureHuntStep
    {
        public new const short ProtocolId = 465;
        public override short TypeId { get { return ProtocolId; } }

        public TreasureHuntStepDig(): base()
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