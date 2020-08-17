namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    using Types.Game.Context;
    using System.Collections.Generic;
    using Utils.IO;

    public class GameMapChangeOrientationsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6155;
        public override ushort MessageID => ProtocolId;
        public List<ActorOrientation> Orientations { get; set; }

        public GameMapChangeOrientationsMessage(List<ActorOrientation> orientations)
        {
            Orientations = orientations;
        }

        public GameMapChangeOrientationsMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Orientations.Count);
            for (var orientationsIndex = 0; orientationsIndex < Orientations.Count; orientationsIndex++)
            {
                var objectToSend = Orientations[orientationsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var orientationsCount = reader.ReadUShort();
            Orientations = new List<ActorOrientation>();
            for (var orientationsIndex = 0; orientationsIndex < orientationsCount; orientationsIndex++)
            {
                var objectToAdd = new ActorOrientation();
                objectToAdd.Deserialize(reader);
                Orientations.Add(objectToAdd);
            }
        }

    }
}
