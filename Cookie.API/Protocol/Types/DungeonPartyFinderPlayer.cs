using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class DungeonPartyFinderPlayer : NetworkType
    {
        public const ushort ProtocolId = 373;

        public override ushort TypeID => ProtocolId;

        public ulong PlayerId { get; set; }
        public string PlayerName { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }
        public ushort Level { get; set; }
        public DungeonPartyFinderPlayer() { }

        public DungeonPartyFinderPlayer( ulong PlayerId, string PlayerName, sbyte Breed, bool Sex, ushort Level ){
            this.PlayerId = PlayerId;
            this.PlayerName = PlayerName;
            this.Breed = Breed;
            this.Sex = Sex;
            this.Level = Level;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(PlayerId);
            writer.WriteUTF(PlayerName);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
            writer.WriteVarUhShort(Level);
        }

        public override void Deserialize(IDataReader reader)
        {
            PlayerId = reader.ReadVarUhLong();
            PlayerName = reader.ReadUTF();
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
            Level = reader.ReadVarUhShort();
        }
    }
}
