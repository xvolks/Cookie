using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class FightExternalInformations : NetworkType
    {
        public const ushort ProtocolId = 117;

        public FightExternalInformations(int fightId, byte fightType, int fightStart, bool fightSpectatorLocked)
        {
            FightId = fightId;
            FightType = fightType;
            FightStart = fightStart;
            FightSpectatorLocked = fightSpectatorLocked;
        }

        public FightExternalInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int FightId { get; set; }
        public byte FightType { get; set; }
        public int FightStart { get; set; }
        public bool FightSpectatorLocked { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(FightId);
            writer.WriteByte(FightType);
            writer.WriteInt(FightStart);
            writer.WriteBoolean(FightSpectatorLocked);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadInt();
            FightType = reader.ReadByte();
            FightStart = reader.ReadInt();
            FightSpectatorLocked = reader.ReadBoolean();
        }
    }
}