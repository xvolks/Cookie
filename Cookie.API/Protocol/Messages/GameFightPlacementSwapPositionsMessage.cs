using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightPlacementSwapPositionsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6544;

        public override ushort MessageID => ProtocolId;

        public List<IdentifiedEntityDispositionInformations> Dispositions { get; set; }
        public GameFightPlacementSwapPositionsMessage() { }

        public GameFightPlacementSwapPositionsMessage( List<IdentifiedEntityDispositionInformations> Dispositions ){
            this.Dispositions = Dispositions;
        }

        public override void Serialize(IDataWriter writer)
        {
			if(Dispositions.Count > 2) throw new System.Exception("Dispositions Count returned greater than 2");
			foreach (var x in Dispositions)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var DispositionsCount = 2;
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
