using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DareListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6661;

        public override ushort MessageID => ProtocolId;

        public List<DareInformations> Dares { get; set; }
        public DareListMessage() { }

        public DareListMessage( List<DareInformations> Dares ){
            this.Dares = Dares;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Dares.Count);
			foreach (var x in Dares)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var DaresCount = reader.ReadShort();
            Dares = new List<DareInformations>();
            for (var i = 0; i < DaresCount; i++)
            {
                var objectToAdd = new DareInformations();
                objectToAdd.Deserialize(reader);
                Dares.Add(objectToAdd);
            }
        }
    }
}
