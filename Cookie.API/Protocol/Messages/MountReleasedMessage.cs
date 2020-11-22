using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MountReleasedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6308;

        public override ushort MessageID => ProtocolId;

        public int MountId { get; set; }
        public MountReleasedMessage() { }

        public MountReleasedMessage( int MountId ){
            this.MountId = MountId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(MountId);
        }

        public override void Deserialize(IDataReader reader)
        {
            MountId = reader.ReadVarInt();
        }
    }
}
