using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class ExchangeMultiCraftCrafterCanUseHisRessourcesMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6020;

        public ExchangeMultiCraftCrafterCanUseHisRessourcesMessage(bool allowed)
        {
            Allowed = allowed;
        }

        public ExchangeMultiCraftCrafterCanUseHisRessourcesMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Allowed { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Allowed);
        }

        public override void Deserialize(IDataReader reader)
        {
            Allowed = reader.ReadBoolean();
        }
    }
}