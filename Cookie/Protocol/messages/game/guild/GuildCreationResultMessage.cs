using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildCreationResultMessage : NetworkMessage
    {
        public const uint ProtocolId = 5554;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Result = 0;

        public GuildCreationResultMessage()
        {
        }

        public GuildCreationResultMessage(
            byte result
        )
        {
            Result = result;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Result);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Result = reader.ReadByte();
        }
    }
}