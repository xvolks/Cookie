using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameMapChangeOrientationsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6155;

        public override ushort MessageID => ProtocolId;

        public List<ActorOrientation> Orientations { get; set; }
        public GameMapChangeOrientationsMessage() { }

        public GameMapChangeOrientationsMessage( List<ActorOrientation> Orientations ){
            this.Orientations = Orientations;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Orientations.Count);
			foreach (var x in Orientations)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var OrientationsCount = reader.ReadShort();
            Orientations = new List<ActorOrientation>();
            for (var i = 0; i < OrientationsCount; i++)
            {
                var objectToAdd = new ActorOrientation();
                objectToAdd.Deserialize(reader);
                Orientations.Add(objectToAdd);
            }
        }
    }
}
