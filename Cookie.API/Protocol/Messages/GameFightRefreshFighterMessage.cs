using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightRefreshFighterMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6309;

        public override ushort MessageID => ProtocolId;

        public GameContextActorInformations Informations { get; set; }
        public GameFightRefreshFighterMessage() { }

        public GameFightRefreshFighterMessage( GameContextActorInformations Informations ){
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
