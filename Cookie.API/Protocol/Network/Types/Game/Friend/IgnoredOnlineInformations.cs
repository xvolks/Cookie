using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Friend
{
    public class IgnoredOnlineInformations : IgnoredInformations
    {
        public new const ushort ProtocolId = 105;

        public IgnoredOnlineInformations(ulong playerId, string playerName, sbyte breed, bool sex)
        {
            PlayerId = playerId;
            PlayerName = playerName;
            Breed = breed;
            Sex = sex;
        }

        public IgnoredOnlineInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ulong PlayerId { get; set; }
        public string PlayerName { get; set; }
        public sbyte Breed { get; set; }
        public bool Sex { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(PlayerId);
            writer.WriteUTF(PlayerName);
            writer.WriteSByte(Breed);
            writer.WriteBoolean(Sex);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarUhLong();
            PlayerName = reader.ReadUTF();
            Breed = reader.ReadSByte();
            Sex = reader.ReadBoolean();
        }
    }
}