using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ObjectEffect : NetworkType
    {
        public const ushort ProtocolId = 76;

        public override ushort TypeID => ProtocolId;

        public ushort ActionId { get; set; }
        public ObjectEffect() { }

        public ObjectEffect( ushort ActionId ){
            this.ActionId = ActionId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ActionId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ActionId = reader.ReadVarUhShort();
        }
    }
}
