using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeCrafterJobLevelupMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6598;

        public override ushort MessageID => ProtocolId;

        public byte CrafterJobLevel { get; set; }
        public ExchangeCrafterJobLevelupMessage() { }

        public ExchangeCrafterJobLevelupMessage( byte CrafterJobLevel ){
            this.CrafterJobLevel = CrafterJobLevel;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(CrafterJobLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            CrafterJobLevel = reader.ReadByte();
        }
    }
}
