using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Emote
{
    public class EmoteListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5689;

        public EmoteListMessage(List<byte> emoteIds)
        {
            EmoteIds = emoteIds;
        }

        public EmoteListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<byte> EmoteIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) EmoteIds.Count);
            for (var emoteIdsIndex = 0; emoteIdsIndex < EmoteIds.Count; emoteIdsIndex++)
                writer.WriteByte(EmoteIds[emoteIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var emoteIdsCount = reader.ReadUShort();
            EmoteIds = new List<byte>();
            for (var emoteIdsIndex = 0; emoteIdsIndex < emoteIdsCount; emoteIdsIndex++)
                EmoteIds.Add(reader.ReadByte());
        }
    }
}