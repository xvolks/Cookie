using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Pvp
{
    public class UpdateMapPlayersAgressableStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6454;

        public UpdateMapPlayersAgressableStatusMessage(List<ulong> playerIds, List<byte> enable)
        {
            PlayerIds = playerIds;
            Enable = enable;
        }

        public UpdateMapPlayersAgressableStatusMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<ulong> PlayerIds { get; set; }
        public List<byte> Enable { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) PlayerIds.Count);
            for (var playerIdsIndex = 0; playerIdsIndex < PlayerIds.Count; playerIdsIndex++)
                writer.WriteVarUhLong(PlayerIds[playerIdsIndex]);
            writer.WriteShort((short) Enable.Count);
            for (var enableIndex = 0; enableIndex < Enable.Count; enableIndex++)
                writer.WriteByte(Enable[enableIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var playerIdsCount = reader.ReadUShort();
            PlayerIds = new List<ulong>();
            for (var playerIdsIndex = 0; playerIdsIndex < playerIdsCount; playerIdsIndex++)
                PlayerIds.Add(reader.ReadVarUhLong());
            var enableCount = reader.ReadUShort();
            Enable = new List<byte>();
            for (var enableIndex = 0; enableIndex < enableCount; enableIndex++)
                Enable.Add(reader.ReadByte());
        }
    }
}