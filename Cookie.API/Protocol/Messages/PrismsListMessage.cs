using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PrismsListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6440;

        public override ushort MessageID => ProtocolId;

        public List<PrismSubareaEmptyInfo> Prisms { get; set; }
        public PrismsListMessage() { }

        public PrismsListMessage( List<PrismSubareaEmptyInfo> Prisms ){
            this.Prisms = Prisms;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Prisms.Count);
			foreach (var x in Prisms)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var PrismsCount = reader.ReadShort();
            Prisms = new List<PrismSubareaEmptyInfo>();
            for (var i = 0; i < PrismsCount; i++)
            {
                PrismSubareaEmptyInfo objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Prisms.Add(objectToAdd);
            }
        }
    }
}
