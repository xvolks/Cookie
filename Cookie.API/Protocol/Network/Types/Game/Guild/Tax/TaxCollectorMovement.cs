using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Guild.Tax
{
    public class TaxCollectorMovement : NetworkType
    {
        public const ushort ProtocolId = 493;

        public TaxCollectorMovement(byte movementType, TaxCollectorBasicInformations basicInfos, ulong playerId,
            string playerName)
        {
            MovementType = movementType;
            BasicInfos = basicInfos;
            PlayerId = playerId;
            PlayerName = playerName;
        }

        public TaxCollectorMovement()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte MovementType { get; set; }
        public TaxCollectorBasicInformations BasicInfos { get; set; }
        public ulong PlayerId { get; set; }
        public string PlayerName { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(MovementType);
            BasicInfos.Serialize(writer);
            writer.WriteVarUhLong(PlayerId);
            writer.WriteUTF(PlayerName);
        }

        public override void Deserialize(IDataReader reader)
        {
            MovementType = reader.ReadByte();
            BasicInfos = new TaxCollectorBasicInformations();
            BasicInfos.Deserialize(reader);
            PlayerId = reader.ReadVarUhLong();
            PlayerName = reader.ReadUTF();
        }
    }
}