namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using Types.Game.Context;
    using Types.Game.Look;
    using Types.Game.Prism;
    using Utils.IO;

    public class GameRolePlayPrismInformations : GameRolePlayActorInformations
    {
        public new const ushort ProtocolId = 161;
        public override ushort TypeID => ProtocolId;
        public PrismInformation Prism { get; set; }

        public GameRolePlayPrismInformations(PrismInformation prism)
        {
            Prism = prism;
        }

        public GameRolePlayPrismInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort(Prism.TypeID);
            Prism.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Prism = ProtocolTypeManager.GetInstance<PrismInformation>(reader.ReadUShort());
            Prism.Deserialize(reader);
        }

    }
}
