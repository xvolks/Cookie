using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TaxCollectorMovementMessage : NetworkMessage
    {
        public const uint ProtocolId = 5633;
        public override uint MessageID { get { return ProtocolId; } }

        public byte MovementType = 0;
        public TaxCollectorBasicInformations BasicInfos;
        public long PlayerId = 0;
        public string PlayerName;

        public TaxCollectorMovementMessage()
        {
        }

        public TaxCollectorMovementMessage(
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