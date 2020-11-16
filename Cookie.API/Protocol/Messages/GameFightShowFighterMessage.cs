using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightShowFighterMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5864;

        public override ushort MessageID => ProtocolId;

        public GameFightFighterInformations Informations { get; set; }
        public GameFightShowFighterMessage() { }

        public GameFightShowFighterMessage( GameFightFighterInformations Informations ){
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
