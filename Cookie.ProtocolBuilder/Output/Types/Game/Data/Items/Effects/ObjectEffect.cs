namespace Cookie.API.Protocol.Network.Types.Game.Data.Items.Effects
{
    using Utils.IO;

    public class ObjectEffect : NetworkType
    {
        public const ushort ProtocolId = 76;
        public override ushort TypeID => ProtocolId;
        public ushort ActionId { get; set; }

        public ObjectEffect(ushort actionId)
        {
            ActionId = actionId;
        }

        public ObjectEffect() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ActionId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ActionId = reader.ReadVarUhShort();
        }

    }
}
