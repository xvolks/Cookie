using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class HumanOptionOrnament : HumanOption
    {
        public new const ushort ProtocolId = 411;

        public HumanOptionOrnament(ushort ornamentId)
        {
            OrnamentId = ornamentId;
        }

        public HumanOptionOrnament()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort OrnamentId { get; set; }

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