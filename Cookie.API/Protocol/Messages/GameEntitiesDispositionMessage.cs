using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameEntitiesDispositionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5696;

        public override ushort MessageID => ProtocolId;

        public List<IdentifiedEntityDispositionInformations> Dispositions { get; set; }
        public GameEntitiesDispositionMessage() { }

        public GameEntitiesDispositionMessage( List<IdentifiedEntityDispositionInformations> Dispositions ){
            this.Dispositions = Dispositions;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Dispositions.Count);
			foreach (var x in Dispositions)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var DispositionsCount = reader.ReadShort();
            Dispositions = new List<IdentifiedEntityDispositionInformations>();
            for (var i = 0; i < DispositionsCount; i++)
            {
                var objectToAdd = new IdentifiedEntityDispositionInformations();
                objectToAdd.Deserialize(reader);
                Dispositions.Add(objectToAdd);
            }
        }
    }
}
