using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Chat.Channel
{
    public class EnabledChannelsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 892;

        public EnabledChannelsMessage(List<byte> channels, List<byte> disallowed)
        {
            Channels = channels;
            Disallowed = disallowed;
        }

        public EnabledChannelsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<byte> Channels { get; set; }
        public List<byte> Disallowed { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Channels.Count);
            for (var channelsIndex = 0; channelsIndex < Channels.Count; channelsIndex++)
                writer.WriteByte(Channels[channelsIndex]);
            writer.WriteShort((short) Disallowed.Count);
            for (var disallowedIndex = 0; disallowedIndex < Disallowed.Count; disallowedIndex++)
                writer.WriteByte(Disallowed[disallowedIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var channelsCount = reader.ReadUShort();
            Channels = new List<byte>();
            for (var channelsIndex = 0; channelsIndex < channelsCount; channelsIndex++)
                Channels.Add(reader.ReadByte());
            var disallowedCount = reader.ReadUShort();
            Disallowed = new List<byte>();
            for (var disallowedIndex = 0; disallowedIndex < disallowedCount; disallowedIndex++)
                Disallowed.Add(reader.ReadByte());
        }
    }
}