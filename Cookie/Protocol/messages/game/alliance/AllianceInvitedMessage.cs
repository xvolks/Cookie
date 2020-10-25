using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceInvitedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6397;
        public override uint MessageID { get { return ProtocolId; } }

        public long RecruterId = 0;
        public string RecruterName;
        public BasicNamedAllianceInformations AllianceInfo;

        public AllianceInvitedMessage()
        {
        }

        public AllianceInvitedMessage(
            long recruterId,
            string recruterName,
            BasicNamedAllianceInformations allianceInfo
        )
        {
            RecruterId = recruterId;
            RecruterName = recruterName;
            AllianceInfo = allianceInfo;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(RecruterId);
            writer.WriteUTF(RecruterName);
            AllianceInfo.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            RecruterId = reader.ReadVarLong();
            RecruterName = reader.ReadUTF();
            AllianceInfo = new BasicNamedAllianceInformations();
            AllianceInfo.Deserialize(reader);
        }
    }
}