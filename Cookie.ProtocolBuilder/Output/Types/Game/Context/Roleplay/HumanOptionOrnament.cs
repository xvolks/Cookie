namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using Utils.IO;

    public class HumanOptionOrnament : HumanOption
    {
        public new const ushort ProtocolId = 411;
        public override ushort TypeID => ProtocolId;
        public ushort OrnamentId { get; set; }

        public HumanOptionOrnament(ushort ornamentId)
        {
            OrnamentId = ornamentId;
        }

        public HumanOptionOrnament() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(OrnamentId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            OrnamentId = reader.ReadVarUhShort();
        }

    }
}
