using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AllianceJoinedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6402;

        public override ushort MessageID => ProtocolId;

        public AllianceInformations AllianceInfo { get; set; }
        public bool Enabled { get; set; }
        public uint LeadingGuildId { get; set; }
        public AllianceJoinedMessage() { }

        public AllianceJoinedMessage( AllianceInformations AllianceInfo, bool Enabled, uint LeadingGuildId ){
            this.AllianceInfo = AllianceInfo;
            this.Enabled = Enabled;
            this.LeadingGuildId = LeadingGuildId;
        }

        public override void Serialize(IDataWriter writer)
        {
            AllianceInfo.Serialize(writer);
            writer.WriteBoolean(Enabled);
            writer.WriteVarUhInt(LeadingGuildId);
        }

        public override void Deserialize(IDataReader reader)
        {
            AllianceInfo = new AllianceInformations();
            AllianceInfo.Deserialize(reader);
            Enabled = reader.ReadBoolean();
            LeadingGuildId = reader.ReadVarUhInt();
        }
    }
}
