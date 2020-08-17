using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    public class AllianceCreationResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6391;

        public AllianceCreationResultMessage(byte result)
        {
            Result = result;
        }

        public AllianceCreationResultMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Result { get; set; }

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