using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class AbstractCharacterInformation : NetworkType
    {
        public const ushort ProtocolId = 400;

        public override ushort TypeID => ProtocolId;

        public ulong Id { get; set; }
        public AbstractCharacterInformation() { }

        public AbstractCharacterInformation( ulong Id ){
            this.Id = Id;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(Id);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadVarUhLong();
        }
    }
}
