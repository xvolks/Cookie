using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Character.Choice
{
    public class CharacterHardcoreOrEpicInformations : CharacterBaseInformations
    {
        public new const ushort ProtocolId = 474;

        public CharacterHardcoreOrEpicInformations(byte deathState, ushort deathCount, byte deathMaxLevel)
        {
            DeathState = deathState;
            DeathCount = deathCount;
            DeathMaxLevel = deathMaxLevel;
        }

        public CharacterHardcoreOrEpicInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte DeathState { get; set; }
        public ushort DeathCount { get; set; }
        public byte DeathMaxLevel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(DeathState);
            writer.WriteVarUhShort(DeathCount);
            writer.WriteByte(DeathMaxLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            DeathState = reader.ReadByte();
            DeathCount = reader.ReadVarUhShort();
            DeathMaxLevel = reader.ReadByte();
        }
    }
}