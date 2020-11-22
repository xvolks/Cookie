using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class EnabledChannelsMessage : NetworkMessage
    {
        public const uint ProtocolId = 892;
        public override uint MessageID { get { return ProtocolId; } }

        public List<byte> Channels;
        public List<byte> Disallowed;

        public EnabledChannelsMessage()
        {
        }

        public EnabledChannelsMessage(
            List<byte> channels,
            List<byte> disallowed
        )
        {
            Channels = channels;
            Disallowed = disallowed;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Channels.Count());
            foreach (var current in Channels)
            {
                writer.WriteByte(current);
            }
            writer.WriteShort((short)Disallowed.Count());
            foreach (var current in Disallowed)
            {
                writer.WriteByte(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countChannels = reader.ReadShort();
            Channels = new List<byte>();
            for (short i = 0; i < countChannels; i++)
            {
                Channels.Add(reader.ReadByte());
            }
            var countDisallowed = reader.ReadShort();
            Disallowed = new List<byte>();
            for (short i = 0; i < countDisallowed; i++)
            {
                Disallowed.Add(reader.ReadByte());
            }
        }
    }
}