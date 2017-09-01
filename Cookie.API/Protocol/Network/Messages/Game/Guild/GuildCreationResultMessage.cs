using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildCreationResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5554;

        public GuildCreationResultMessage(byte result)
        {
            Result = result;
        }

        public GuildCreationResultMessage()
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