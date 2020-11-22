using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ObtainedItemWithBonusMessage : ObtainedItemMessage
    {
        public new const ushort ProtocolId = 6520;

        public override ushort MessageID => ProtocolId;

        public uint BonusQuantity { get; set; }
        public ObtainedItemWithBonusMessage() { }

        public ObtainedItemWithBonusMessage( uint BonusQuantity ){
            this.BonusQuantity = BonusQuantity;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(BonusQuantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            BonusQuantity = reader.ReadVarUhInt();
        }
    }
}
