using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class EnabledChannelsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 892;

        public override ushort MessageID => ProtocolId;

        public List<sbyte> Channels { get; set; }
        public List<sbyte> Disallowed { get; set; }
        public EnabledChannelsMessage() { }

        public EnabledChannelsMessage( List<sbyte> Channels, List<sbyte> Disallowed ){
            this.Channels = Channels;
            this.Disallowed = Disallowed;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Channels.Count);
			foreach (var x in Channels)
			{
				writer.WriteSByte(x);
			}
			writer.WriteShort((short)Disallowed.Count);
			foreach (var x in Disallowed)
			{
				writer.WriteSByte(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var ChannelsCount = reader.ReadShort();
            Channels = new List<sbyte>();
            for (var i = 0; i < ChannelsCount; i++)
            {
                Channels.Add(reader.ReadSByte());
            }
            var DisallowedCount = reader.ReadShort();
            Disallowed = new List<sbyte>();
            for (var i = 0; i < DisallowedCount; i++)
            {
                Disallowed.Add(reader.ReadSByte());
            }
        }
    }
}
