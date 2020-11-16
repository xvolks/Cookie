using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayShowActorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5632;

        public override ushort MessageID => ProtocolId;

        public GameRolePlayActorInformations Informations { get; set; }
        public GameRolePlayShowActorMessage() { }

        public GameRolePlayShowActorMessage( GameRolePlayActorInformations Informations ){
            this.Informations = Informations;
        }

        public override void Serialize(IDataWriter writer)
        {
            Informations.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Informations = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Informations.Deserialize(reader);
        }
    }
}
