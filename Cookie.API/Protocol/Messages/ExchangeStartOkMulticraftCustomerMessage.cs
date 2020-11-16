using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeStartOkMulticraftCustomerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5817;

        public override ushort MessageID => ProtocolId;

        public uint SkillId { get; set; }
        public byte CrafterJobLevel { get; set; }
        public ExchangeStartOkMulticraftCustomerMessage() { }

        public ExchangeStartOkMulticraftCustomerMessage( uint SkillId, byte CrafterJobLevel ){
            this.SkillId = SkillId;
            this.CrafterJobLevel = CrafterJobLevel;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(SkillId);
            writer.WriteByte(CrafterJobLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            SkillId = reader.ReadVarUhInt();
            CrafterJobLevel = reader.ReadByte();
        }
    }
}
