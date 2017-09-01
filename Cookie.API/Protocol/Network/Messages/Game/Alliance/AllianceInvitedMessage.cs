using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    public class AllianceInvitedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6397;

        public AllianceInvitedMessage(ulong recruterId, string recruterName,
            BasicNamedAllianceInformations allianceInfo)
        {
            RecruterId = recruterId;
            RecruterName = recruterName;
            AllianceInfo = allianceInfo;
        }

        public AllianceInvitedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong RecruterId { get; set; }
        public string RecruterName { get; set; }
        public BasicNamedAllianceInformations AllianceInfo { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(RecruterId);
            writer.WriteUTF(RecruterName);
            AllianceInfo.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            RecruterId = reader.ReadVarUhLong();
            RecruterName = reader.ReadUTF();
            AllianceInfo = new BasicNamedAllianceInformations();
            AllianceInfo.Deserialize(reader);
        }
    }
}