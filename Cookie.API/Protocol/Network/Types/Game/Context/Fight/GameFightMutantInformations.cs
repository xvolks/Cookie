using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class GameFightMutantInformations : GameFightFighterNamedInformations
    {
        public new const ushort ProtocolId = 50;

        public GameFightMutantInformations(byte powerLevel)
        {
            PowerLevel = powerLevel;
        }

        public GameFightMutantInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte PowerLevel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(PowerLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PowerLevel = reader.ReadByte();
        }
    }
}