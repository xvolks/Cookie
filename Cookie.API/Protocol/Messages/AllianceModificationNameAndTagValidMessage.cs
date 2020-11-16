using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AllianceModificationNameAndTagValidMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6449;

        public override ushort MessageID => ProtocolId;

        public string AllianceName { get; set; }
        public string AllianceTag { get; set; }
        public AllianceModificationNameAndTagValidMessage() { }

        public AllianceModificationNameAndTagValidMessage( string AllianceName, string AllianceTag ){
            this.AllianceName = AllianceName;
            this.AllianceTag = AllianceTag;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(AllianceName);
            writer.WriteUTF(AllianceTag);
        }

        public override void Deserialize(IDataReader reader)
        {
            AllianceName = reader.ReadUTF();
            AllianceTag = reader.ReadUTF();
        }
    }
}
