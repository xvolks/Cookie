using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ProtectedEntityWaitingForHelpInfo : NetworkType
    {
        public const short ProtocolId = 186;
        public override short TypeId { get { return ProtocolId; } }

        public int TimeLeftBeforeFight = 0;
        public int WaitTimeForPlacement = 0;
        public byte NbPositionForDefensors = 0;

        public ProtectedEntityWaitingForHelpInfo()
        {
        }

        public ProtectedEntityWaitingForHelpInfo(
            int timeLeftBeforeFight,
            int waitTimeForPlacement,
            byte nbPositionForDefensors
        )
        {
            TimeLeftBeforeFight = timeLeftBeforeFight;
            WaitTimeForPlacement = waitTimeForPlacement;
            NbPositionForDefensors = nbPositionForDefensors;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(TimeLeftBeforeFight);
            writer.WriteInt(WaitTimeForPlacement);
            writer.WriteByte(NbPositionForDefensors);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            TimeLeftBeforeFight = reader.ReadInt();
            WaitTimeForPlacement = reader.ReadInt();
            NbPositionForDefensors = reader.ReadByte();
        }
    }
}