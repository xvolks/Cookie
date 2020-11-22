using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AllianceInvitedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6397;

        public override ushort MessageID => ProtocolId;

        public ulong RecruterId { get; set; }
        public string RecruterName { get; set; }
        public BasicNamedAllianceInformations AllianceInfo { get; set; }
        public AllianceInvitedMessage() { }

        public AllianceInvitedMessage( ulong RecruterId, string RecruterName, BasicNamedAllianceInformations AllianceInfo ){
            this.RecruterId = RecruterId;
            this.RecruterName = RecruterName;
            this.AllianceInfo = AllianceInfo;
        }

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
