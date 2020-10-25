using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildPaddockTeleportRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5957;
        public override uint MessageID { get { return ProtocolId; } }

        public double PaddockId = 0;

        public GuildPaddockTeleportRequestMessage()
        {
        }

        public GuildPaddockTeleportRequestMessage(
            double paddockId
        )
        {
            PaddockId = paddockId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(PaddockId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PaddockId = reader.ReadDouble();
        }
    }
}