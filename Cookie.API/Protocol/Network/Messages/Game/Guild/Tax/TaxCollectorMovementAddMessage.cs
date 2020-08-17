namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    using Types.Game.Guild.Tax;
    using Utils.IO;

    public class TaxCollectorMovementAddMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5917;
        public override ushort MessageID => ProtocolId;
        public TaxCollectorInformations Informations { get; set; }

        public TaxCollectorMovementAddMessage(TaxCollectorInformations informations)
        {
            Informations = informations;
        }

        public TaxCollectorMovementAddMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort(Informations.TypeID);
            Informations.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Informations = ProtocolTypeManager.GetInstance<TaxCollectorInformations>(reader.ReadUShort());
            Informations.Deserialize(reader);
        }

    }
}
