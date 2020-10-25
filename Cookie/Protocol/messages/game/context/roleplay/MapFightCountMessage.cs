using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MapFightCountMessage : NetworkMessage
    {
        public const uint ProtocolId = 210;
        public override uint MessageID { get { return ProtocolId; } }

        public short FightCount = 0;

        public MapFightCountMessage()
        {
        }

        public MapFightCountMessage(
            short fightCount
        )
        {
            FightCount = fightCount;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(FightCount);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FightCount = reader.ReadVarShort();
        }
    }
}