using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildPaddockTeleportRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5957;

        public override ushort MessageID => ProtocolId;

        public double PaddockId { get; set; }
        public GuildPaddockTeleportRequestMessage() { }

        public GuildPaddockTeleportRequestMessage( double PaddockId ){
            this.PaddockId = PaddockId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(PaddockId);
        }

        public override void Deserialize(IDataReader reader)
        {
            PaddockId = reader.ReadDouble();
        }
    }
}
