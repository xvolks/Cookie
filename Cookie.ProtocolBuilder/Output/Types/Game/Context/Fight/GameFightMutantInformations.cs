namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    using Types.Game.Character.Status;
    using Types.Game.Context;
    using Types.Game.Look;
    using System.Collections.Generic;
    using Utils.IO;

    public class GameFightMutantInformations : GameFightFighterNamedInformations
    {
        public new const ushort ProtocolId = 50;
        public override ushort TypeID => ProtocolId;
        public byte PowerLevel { get; set; }

        public GameFightMutantInformations(byte powerLevel)
        {
            PowerLevel = powerLevel;
        }

        public GameFightMutantInformations() { }

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
