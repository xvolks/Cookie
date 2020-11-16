using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class MigratedServerListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6731;
        public override uint MessageID { get { return ProtocolId; } }

        public List<short> MigratedServerIds;

        public MigratedServerListMessage()
        {
        }

        public MigratedServerListMessage(
            List<short> migratedServerIds
        )
        {
            MigratedServerIds = migratedServerIds;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)MigratedServerIds.Count());
            foreach (var current in MigratedServerIds)
            {
                writer.WriteVarShort(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countMigratedServerIds = reader.ReadShort();
            MigratedServerIds = new List<short>();
            for (short i = 0; i < countMigratedServerIds; i++)
            {
                MigratedServerIds.Add(reader.ReadVarShort());
            }
        }
    }
}