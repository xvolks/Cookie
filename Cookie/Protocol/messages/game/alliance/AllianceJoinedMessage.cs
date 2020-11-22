using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceJoinedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6402;
        public override uint MessageID { get { return ProtocolId; } }

        public AllianceInformations AllianceInfo;
        public bool Enabled = false;
        public int LeadingGuildId = 0;

        public AllianceJoinedMessage()
        {
        }

        public AllianceJoinedMessage(
            AllianceInformations allianceInfo,
            bool enabled,
            int leadingGuildId
        )
        {
            AllianceInfo = allianceInfo;
            Enabled = enabled;
            LeadingGuildId = leadingGuildId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            AllianceInfo.Serialize(writer);
            writer.WriteBoolean(Enabled);
            writer.WriteVarInt(LeadingGuildId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            AllianceInfo = new AllianceInformations();
            AllianceInfo.Deserialize(reader);
            Enabled = reader.ReadBoolean();
            LeadingGuildId = reader.ReadVarInt();
        }
    }
}