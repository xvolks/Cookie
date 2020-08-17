namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeSetCraftRecipeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6389;
        public override ushort MessageID => ProtocolId;
        public ushort ObjectGID { get; set; }

        public ExchangeSetCraftRecipeMessage(ushort objectGID)
        {
            ObjectGID = objectGID;
        }

        public ExchangeSetCraftRecipeMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ObjectGID);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectGID = reader.ReadVarUhShort();
        }

    }
}
