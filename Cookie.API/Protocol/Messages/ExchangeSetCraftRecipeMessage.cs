using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeSetCraftRecipeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6389;

        public override ushort MessageID => ProtocolId;

        public ushort ObjectGID { get; set; }
        public ExchangeSetCraftRecipeMessage() { }

        public ExchangeSetCraftRecipeMessage( ushort ObjectGID ){
            this.ObjectGID = ObjectGID;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ObjectGID);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectGID = reader.ReadVarUhShort();
        }
    }
}
