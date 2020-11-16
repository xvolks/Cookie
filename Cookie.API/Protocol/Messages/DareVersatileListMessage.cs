using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DareVersatileListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6657;

        public override ushort MessageID => ProtocolId;

        public List<DareVersatileInformations> Dares { get; set; }
        public DareVersatileListMessage() { }

        public DareVersatileListMessage( List<DareVersatileInformations> Dares ){
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
            Dares = new List<DareVersatileInformations>();
            for (var i = 0; i < DaresCount; i++)
            {
                var objectToAdd = new DareVersatileInformations();
                objectToAdd.Deserialize(reader);
                Dares.Add(objectToAdd);
            }
        }
    }
}
