using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeStartOkMulticraftCrafterMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5818;

        public override ushort MessageID => ProtocolId;

        public uint SkillId { get; set; }
        public ExchangeStartOkMulticraftCrafterMessage() { }

        public ExchangeStartOkMulticraftCrafterMessage( uint SkillId ){
            this.SkillId = SkillId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(SkillId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SkillId = reader.ReadVarUhInt();
        }
    }
}
