using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ServerOptionalFeaturesMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6305;

        public override ushort MessageID => ProtocolId;

        public List<sbyte> Features { get; set; }
        public ServerOptionalFeaturesMessage() { }

        public ServerOptionalFeaturesMessage( List<sbyte> Features ){
            this.Features = Features;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Features.Count);
			foreach (var x in Features)
			{
				writer.WriteSByte(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var FeaturesCount = reader.ReadShort();
            Features = new List<sbyte>();
            for (var i = 0; i < FeaturesCount; i++)
            {
                Features.Add(reader.ReadSByte());
            }
        }
    }
}
