using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    public class AllianceInvitationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6395;

        public AllianceInvitationMessage(ulong targetId)
        {
            TargetId = targetId;
        }

        public AllianceInvitationMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong TargetId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(TargetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TargetId = reader.ReadVarUhLong();
        }
    }
}