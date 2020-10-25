using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ChatSmileyExtraPackListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6596;
        public override uint MessageID { get { return ProtocolId; } }

        public List<byte> PackIds;

        public ChatSmileyExtraPackListMessage()
        {
        }

        public ChatSmileyExtraPackListMessage(
            List<byte> packIds
        )
        {
            PackIds = packIds;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)PackIds.Count());
            foreach (var current in PackIds)
            {
                writer.WriteByte(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countPackIds = reader.ReadShort();
            PackIds = new List<byte>();
            for (short i = 0; i < countPackIds; i++)
            {
                PackIds.Add(reader.ReadByte());
            }
        }
    }
}