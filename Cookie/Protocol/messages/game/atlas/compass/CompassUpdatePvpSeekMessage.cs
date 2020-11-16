using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CompassUpdatePvpSeekMessage : CompassUpdateMessage
    {
        public new const uint ProtocolId = 6013;
        public override uint MessageID { get { return ProtocolId; } }

        public long MemberId = 0;
        public string MemberName;

        public CompassUpdatePvpSeekMessage(): base()
        {
        }

        public CompassUpdatePvpSeekMessage(
            byte type,
            MapCoordinates coords,
            long memberId,
            string memberName
        ): base(
            type,
            coords
        )
        {
            MemberId = memberId;
            MemberName = memberName;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(MemberId);
            writer.WriteUTF(MemberName);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            MemberId = reader.ReadVarLong();
            MemberName = reader.ReadUTF();
        }
    }
}