using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeCraftResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5790;

        public override ushort MessageID => ProtocolId;

        public sbyte CraftResult { get; set; }
        public ExchangeCraftResultMessage() { }

        public ExchangeCraftResultMessage( sbyte CraftResult ){
            this.CraftResult = CraftResult;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(CraftResult);
        }

        public override void Deserialize(IDataReader reader)
        {
            CraftResult = reader.ReadSByte();
        }
    }
}
