using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class EmoteListMessage : NetworkMessage
    {
        public const uint ProtocolId = 5689;
        public override uint MessageID { get { return ProtocolId; } }

        public List<byte> EmoteIds;

        public EmoteListMessage()
        {
        }

        public EmoteListMessage(
            List<byte> emoteIds
        )
        {
            EmoteIds = emoteIds;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)EmoteIds.Count());
            foreach (var current in EmoteIds)
            {
                writer.WriteByte(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countEmoteIds = reader.ReadShort();
            EmoteIds = new List<byte>();
            for (short i = 0; i < countEmoteIds; i++)
            {
                EmoteIds.Add(reader.ReadByte());
            }
        }
    }
}