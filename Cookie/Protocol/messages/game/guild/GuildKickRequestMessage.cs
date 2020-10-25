using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildKickRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5887;
        public override uint MessageID { get { return ProtocolId; } }

        public long KickedId = 0;

        public GuildKickRequestMessage()
        {
        }

        public GuildKickRequestMessage(
            long kickedId
        )
        {
            KickedId = kickedId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(KickedId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            KickedId = reader.ReadVarLong();
        }
    }
}