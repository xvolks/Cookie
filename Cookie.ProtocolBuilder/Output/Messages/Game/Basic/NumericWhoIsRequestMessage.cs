namespace Cookie.API.Protocol.Network.Messages.Game.Basic
{
    using Utils.IO;

    public class NumericWhoIsRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6298;
        public override ushort MessageID => ProtocolId;
        public ulong PlayerId { get; set; }

        public NumericWhoIsRequestMessage(ulong playerId)
        {
            PlayerId = playerId;
        }

        public NumericWhoIsRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PlayerId = reader.ReadVarUhLong();
        }

    }
}
