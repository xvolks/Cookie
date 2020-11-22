using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangePlayerMultiCraftRequestMessage : ExchangeRequestMessage
    {
        public new const ushort ProtocolId = 5784;

        public override ushort MessageID => ProtocolId;

        public ulong Target { get; set; }
        public uint SkillId { get; set; }
        public ExchangePlayerMultiCraftRequestMessage() { }

        public ExchangePlayerMultiCraftRequestMessage( ulong Target, uint SkillId ){
            this.Target = Target;
            this.SkillId = SkillId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(Target);
            writer.WriteVarUhInt(SkillId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Target = reader.ReadVarUhLong();
            SkillId = reader.ReadVarUhInt();
        }
    }
}
