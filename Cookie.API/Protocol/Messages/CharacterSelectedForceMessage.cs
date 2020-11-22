using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CharacterSelectedForceMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6068;

        public override ushort MessageID => ProtocolId;

        public int Id { get; set; }
        public CharacterSelectedForceMessage() { }

        public CharacterSelectedForceMessage( int Id ){
            this.Id = Id;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(Id);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadInt();
        }
    }
}
