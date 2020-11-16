using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildGetInformationsMessage : NetworkMessage
    {
        public const uint ProtocolId = 5550;
        public override uint MessageID { get { return ProtocolId; } }

        public byte InfoType = 0;

        public GuildGetInformationsMessage()
        {
        }

        public GuildGetInformationsMessage(
            byte infoType
        )
        {
            InfoType = infoType;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(InfoType);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            InfoType = reader.ReadByte();
        }
    }
}