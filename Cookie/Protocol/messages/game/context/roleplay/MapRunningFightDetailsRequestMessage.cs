using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MapRunningFightDetailsRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5750;
        public override uint MessageID { get { return ProtocolId; } }

        public short FightId = 0;

        public MapRunningFightDetailsRequestMessage()
        {
        }

        public MapRunningFightDetailsRequestMessage(
            short fightId
        )
        {
            FightId = fightId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(FightId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FightId = reader.ReadVarShort();
        }
    }
}