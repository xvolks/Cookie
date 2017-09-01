using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Connection
{
    public class MigratedServerListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6731;

        public MigratedServerListMessage(List<ushort> migratedServerIds)
        {
            MigratedServerIds = migratedServerIds;
        }

        public MigratedServerListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<ushort> MigratedServerIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) MigratedServerIds.Count);
            for (var migratedServerIdsIndex = 0;
                migratedServerIdsIndex < MigratedServerIds.Count;
                migratedServerIdsIndex++)
                writer.WriteVarUhShort(MigratedServerIds[migratedServerIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var migratedServerIdsCount = reader.ReadUShort();
            MigratedServerIds = new List<ushort>();
            for (var migratedServerIdsIndex = 0;
                migratedServerIdsIndex < migratedServerIdsCount;
                migratedServerIdsIndex++)
                MigratedServerIds.Add(reader.ReadVarUhShort());
        }
    }
}