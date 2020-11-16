using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class TaxCollectorMovement : NetworkType
    {
        public const short ProtocolId = 493;
        public override short TypeId { get { return ProtocolId; } }

        public byte MovementType = 0;
        public TaxCollectorBasicInformations BasicInfos;
        public long PlayerId = 0;
        public string PlayerName;

        public TaxCollectorMovement()
        {
        }

        public TaxCollectorMovement(
            byte movementType,
            TaxCollectorBasicInformations basicInfos,
            long playerId,
            string playerName
        )
        {
            MovementType = movementType;
            BasicInfos = basicInfos;
            PlayerId = playerId;
            PlayerName = playerName;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(MovementType);
            BasicInfos.Serialize(writer);
            writer.WriteVarLong(PlayerId);
            writer.WriteUTF(PlayerName);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MovementType = reader.ReadByte();
            BasicInfos = new TaxCollectorBasicInformations();
            BasicInfos.Deserialize(reader);
            PlayerId = reader.ReadVarLong();
            PlayerName = reader.ReadUTF();
        }
    }
}