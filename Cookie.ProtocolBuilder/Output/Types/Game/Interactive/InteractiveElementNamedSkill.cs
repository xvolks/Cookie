namespace Cookie.API.Protocol.Network.Types.Game.Interactive
{
    using Utils.IO;

    public class InteractiveElementNamedSkill : InteractiveElementSkill
    {
        public new const ushort ProtocolId = 220;
        public override ushort TypeID => ProtocolId;
        public uint NameId { get; set; }

        public InteractiveElementNamedSkill(uint nameId)
        {
            NameId = nameId;
        }

        public InteractiveElementNamedSkill() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(NameId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            NameId = reader.ReadVarUhInt();
        }

    }
}
