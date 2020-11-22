using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeStartOkCraftWithInformationMessage : ExchangeStartOkCraftMessage
    {
        public new const ushort ProtocolId = 5941;

        public override ushort MessageID => ProtocolId;

        public uint SkillId { get; set; }
        public ExchangeStartOkCraftWithInformationMessage() { }

        public ExchangeStartOkCraftWithInformationMessage( uint SkillId ){
            this.SkillId = SkillId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(SkillId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SkillId = reader.ReadVarUhInt();
        }
    }
}
