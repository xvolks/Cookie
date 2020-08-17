namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Types.Game.Data.Items.Effects;
    using System.Collections.Generic;
    using Utils.IO;

    public class ExchangeBidHouseInListUpdatedMessage : ExchangeBidHouseInListAddedMessage
    {
        public new const ushort ProtocolId = 6337;
        public override ushort MessageID => ProtocolId;

        public ExchangeBidHouseInListUpdatedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }

    }
}
