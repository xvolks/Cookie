using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class IgnoredOnlineInformations : IgnoredInformations
    {
        public new const short ProtocolId = 105;
        public override short TypeId { get { return ProtocolId; } }

        public long PlayerId = 0;
        public string PlayerName;
        public byte Breed = 0;
        public bool Sex = false;

        public IgnoredOnlineInformations(): base()
        {
        }

        public IgnoredOnlineInformations(
            int accountId,
            string accountName,
            long playerId,
            string playerName,
            byte breed,
            bool sex
        ): base(
            accountId,
            accountName
        )
        {
            PlayerId = playerId;
            PlayerName = playerName;
            Breed = breed;
            Sex = sex;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(PlayerId);
            writer.WriteUTF(PlayerName);
            writer.WriteByte(Breed);
            writer.WriteBoolean(Sex);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarLong();
            PlayerName = reader.ReadUTF();
            Breed = reader.ReadByte();
            Sex = reader.ReadBoolean();
        }
    }
}