using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayShowActorMessage : NetworkMessage
    {
        public const uint ProtocolId = 5632;
        public override uint MessageID { get { return ProtocolId; } }

        public GameRolePlayActorInformations Informations;

        public GameRolePlayShowActorMessage()
        {
        }

        public GameRolePlayShowActorMessage(
            GameRolePlayActorInformations informations
        )
        {
            Informations = informations;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(Informations.TypeId);
            Informations.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var informationsTypeId = reader.ReadShort();
            Informations = new GameRolePlayActorInformations();
            Informations.Deserialize(reader);
        }
    }
}