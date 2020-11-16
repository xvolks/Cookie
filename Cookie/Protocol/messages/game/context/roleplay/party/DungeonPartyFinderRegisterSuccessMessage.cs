using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class DungeonPartyFinderRegisterSuccessMessage : NetworkMessage
    {
        public const uint ProtocolId = 6241;
        public override uint MessageID { get { return ProtocolId; } }

        public List<short> DungeonIds;

        public DungeonPartyFinderRegisterSuccessMessage()
        {
        }

        public DungeonPartyFinderRegisterSuccessMessage(
            List<short> dungeonIds
        )
        {
            DungeonIds = dungeonIds;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)DungeonIds.Count());
            foreach (var current in DungeonIds)
            {
                writer.WriteVarShort(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countDungeonIds = reader.ReadShort();
            DungeonIds = new List<short>();
            for (short i = 0; i < countDungeonIds; i++)
            {
                DungeonIds.Add(reader.ReadVarShort());
            }
        }
    }
}