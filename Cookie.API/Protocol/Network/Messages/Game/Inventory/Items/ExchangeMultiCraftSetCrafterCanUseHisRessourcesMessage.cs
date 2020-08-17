using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6021;

        public ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage(bool allow)
        {
            Allow = allow;
        }

        public ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Allow { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Allow);
        }

        public override void Deserialize(IDataReader reader)
        {
            Allow = reader.ReadBoolean();
        }
    }
}