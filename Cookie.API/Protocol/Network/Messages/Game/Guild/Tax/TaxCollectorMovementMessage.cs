namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    using Types.Game.Guild.Tax;
    using Utils.IO;

    public class TaxCollectorMovementMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5633;
        public override ushort MessageID => ProtocolId;
        public byte MovementType { get; set; }
        public TaxCollectorBasicInformations BasicInfos { get; set; }
        public ulong PlayerId { get; set; }
        public string PlayerName { get; set; }

        public TaxCollectorMovementMessage(byte movementType, TaxCollectorBasicInformations basicInfos, ulong playerId, string playerName)
        {
            MovementType = movementType;
            BasicInfos = basicInfos;
            PlayerId = playerId;
            PlayerName = playerName;
        }

        public TaxCollectorMovementMessage() { }

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
