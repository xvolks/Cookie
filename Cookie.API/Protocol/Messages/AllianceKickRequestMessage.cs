using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AllianceKickRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6400;

        public override ushort MessageID => ProtocolId;

        public uint KickedId { get; set; }
        public AllianceKickRequestMessage() { }

        public AllianceKickRequestMessage( uint KickedId ){
            this.KickedId = KickedId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(KickedId);
        }

        public override void Deserialize(IDataReader reader)
        {
            KickedId = reader.ReadVarUhInt();
        }
    }
}
