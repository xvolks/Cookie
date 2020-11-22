using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ServerSessionConstant : NetworkType
    {
        public const ushort ProtocolId = 430;

        public override ushort TypeID => ProtocolId;

        public ushort Id { get; set; }
        public ServerSessionConstant() { }

        public ServerSessionConstant( ushort Id ){
            this.Id = Id;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(Id);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadVarUhShort();
        }
    }
}
