using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GuildPaddockRemovedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5955;

        public override ushort MessageID => ProtocolId;

        public double PaddockId { get; set; }
        public GuildPaddockRemovedMessage() { }

        public GuildPaddockRemovedMessage( double PaddockId ){
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
