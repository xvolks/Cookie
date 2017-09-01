using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    public class GameFightTurnListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 713;

        public GameFightTurnListMessage(List<double> ids, List<double> deadsIds)
        {
            Ids = ids;
            DeadsIds = deadsIds;
        }

        public GameFightTurnListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<double> Ids { get; set; }
        public List<double> DeadsIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Ids.Count);
            for (var idsIndex = 0; idsIndex < Ids.Count; idsIndex++)
                writer.WriteDouble(Ids[idsIndex]);
            writer.WriteShort((short) DeadsIds.Count);
            for (var deadsIdsIndex = 0; deadsIdsIndex < DeadsIds.Count; deadsIdsIndex++)
                writer.WriteDouble(DeadsIds[deadsIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var idsCount = reader.ReadUShort();
            Ids = new List<double>();
            for (var idsIndex = 0; idsIndex < idsCount; idsIndex++)
                Ids.Add(reader.ReadDouble());
            var deadsIdsCount = reader.ReadUShort();
            DeadsIds = new List<double>();
            for (var deadsIdsIndex = 0; deadsIdsIndex < deadsIdsCount; deadsIdsIndex++)
                DeadsIds.Add(reader.ReadDouble());
        }
    }
}