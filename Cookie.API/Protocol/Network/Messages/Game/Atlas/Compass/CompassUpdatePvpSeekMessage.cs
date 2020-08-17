using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Atlas.Compass
{
    public class CompassUpdatePvpSeekMessage : CompassUpdateMessage
    {
        public new const ushort ProtocolId = 6013;

        public CompassUpdatePvpSeekMessage(ulong memberId, string memberName)
        {
            MemberId = memberId;
            MemberName = memberName;
        }

        public CompassUpdatePvpSeekMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong MemberId { get; set; }
        public string MemberName { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(MemberId);
            writer.WriteUTF(MemberName);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MemberId = reader.ReadVarUhLong();
            MemberName = reader.ReadUTF();
        }
    }
}