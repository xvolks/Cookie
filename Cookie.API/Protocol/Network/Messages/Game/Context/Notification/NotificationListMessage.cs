using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Notification
{
    public class NotificationListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6087;

        public NotificationListMessage(List<int> flags)
        {
            Flags = flags;
        }

        public NotificationListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<int> Flags { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Flags.Count);
            for (var flagsIndex = 0; flagsIndex < Flags.Count; flagsIndex++)
                writer.WriteVarInt(Flags[flagsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var flagsCount = reader.ReadUShort();
            Flags = new List<int>();
            for (var flagsIndex = 0; flagsIndex < flagsCount; flagsIndex++)
                Flags.Add(reader.ReadVarInt());
        }
    }
}