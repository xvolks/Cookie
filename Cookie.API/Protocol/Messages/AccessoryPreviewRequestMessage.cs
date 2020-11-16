using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AccessoryPreviewRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6518;

        public override ushort MessageID => ProtocolId;

        public List<short> GenericId { get; set; }
        public AccessoryPreviewRequestMessage() { }

        public AccessoryPreviewRequestMessage( List<short> GenericId ){
            this.GenericId = GenericId;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)GenericId.Count);
			foreach (var x in GenericId)
			{
				writer.WriteVarShort(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var GenericIdCount = reader.ReadShort();
            GenericId = new List<short>();
            for (var i = 0; i < GenericIdCount; i++)
            {
                GenericId.Add(reader.ReadVarShort());
            }
        }
    }
}
