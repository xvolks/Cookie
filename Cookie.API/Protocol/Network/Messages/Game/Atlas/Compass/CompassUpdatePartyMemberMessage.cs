using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Atlas.Compass
{
    public class CompassUpdatePartyMemberMessage : CompassUpdateMessage
    {
        public new const ushort ProtocolId = 5589;

        public CompassUpdatePartyMemberMessage(ulong memberId, bool active)
        {
            MemberId = memberId;
            Active = active;
        }

        public CompassUpdatePartyMemberMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong MemberId { get; set; }
        public bool Active { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(MemberId);
            writer.WriteBoolean(Active);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MemberId = reader.ReadVarUhLong();
            Active = reader.ReadBoolean();
        }
    }
}