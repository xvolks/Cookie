using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AllianceFactsRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6409;

        public override ushort MessageID => ProtocolId;

        public uint AllianceId { get; set; }
        public AllianceFactsRequestMessage() { }

        public AllianceFactsRequestMessage( uint AllianceId ){
            this.AllianceId = AllianceId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(AllianceId);
        }

        public override void Deserialize(IDataReader reader)
        {
            AllianceId = reader.ReadVarUhInt();
        }
    }
}
