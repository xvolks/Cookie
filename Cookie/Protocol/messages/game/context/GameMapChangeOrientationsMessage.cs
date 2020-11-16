using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameMapChangeOrientationsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6155;
        public override uint MessageID { get { return ProtocolId; } }

        public List<ActorOrientation> Orientations;

        public GameMapChangeOrientationsMessage()
        {
        }

        public GameMapChangeOrientationsMessage(
            List<ActorOrientation> orientations
        )
        {
            Orientations = orientations;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Orientations.Count());
            foreach (var current in Orientations)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countOrientations = reader.ReadShort();
            Orientations = new List<ActorOrientation>();
            for (short i = 0; i < countOrientations; i++)
            {
                ActorOrientation type = new ActorOrientation();
                type.Deserialize(reader);
                Orientations.Add(type);
            }
        }
    }
}