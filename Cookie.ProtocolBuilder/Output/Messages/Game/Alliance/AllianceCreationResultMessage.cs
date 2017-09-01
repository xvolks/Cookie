namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    using Utils.IO;

    public class AllianceCreationResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6391;
        public override ushort MessageID => ProtocolId;
        public byte Result { get; set; }

        public AllianceCreationResultMessage(byte result)
        {
            Result = result;
        }

        public AllianceCreationResultMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Result);
        }

        public override void Deserialize(IDataReader reader)
        {
            Result = reader.ReadByte();
        }

    }
}
