using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class DungeonPartyFinderPlayer : NetworkType
    {
        public const short ProtocolId = 373;
        public override short TypeId { get { return ProtocolId; } }

        public long PlayerId = 0;
        public string PlayerName;
        public byte Breed = 0;
        public bool Sex = false;
        public short Level = 0;

        public DungeonPartyFinderPlayer()
        {
        }

        public DungeonPartyFinderPlayer(
            long playerId,
            string playerName,
            byte breed,
            bool sex,
            short level
        )
        {
            PlayerId = playerId;
            PlayerName = playerName;
            Breed = breed;
            Sex = sex;
            Level = level;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(PlayerId);
            writer.WriteUTF(PlayerName);
            writer.WriteByte(Breed);
            writer.WriteBoolean(Sex);
            writer.WriteVarShort(Level);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PlayerId = reader.ReadVarLong();
            PlayerName = reader.ReadUTF();
            Breed = reader.ReadByte();
            Sex = reader.ReadBoolean();
            Level = reader.ReadVarShort();
        }
    }
}