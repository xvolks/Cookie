using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class NotificationListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6087;
        public override uint MessageID { get { return ProtocolId; } }

        public List<int> Flags;

        public NotificationListMessage()
        {
        }

        public NotificationListMessage(
            List<int> flags
        )
        {
            Flags = flags;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Flags.Count());
            foreach (var current in Flags)
            {
                writer.WriteVarInt(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countFlags = reader.ReadShort();
            Flags = new List<int>();
            for (short i = 0; i < countFlags; i++)
            {
                Flags.Add(reader.ReadVarInt());
            }
        }
    }
}