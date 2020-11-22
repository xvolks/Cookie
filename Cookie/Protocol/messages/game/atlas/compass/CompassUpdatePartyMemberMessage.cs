using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CompassUpdatePartyMemberMessage : CompassUpdateMessage
    {
        public new const uint ProtocolId = 5589;
        public override uint MessageID { get { return ProtocolId; } }

        public long MemberId = 0;
        public bool Active = false;

        public CompassUpdatePartyMemberMessage(): base()
        {
        }

        public CompassUpdatePartyMemberMessage(
            byte type,
            MapCoordinates coords,
            long memberId,
            bool active
        ): base(
            type,
            coords
        )
        {
            MemberId = memberId;
            Active = active;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(MemberId);
            writer.WriteBoolean(Active);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            MemberId = reader.ReadVarLong();
            Active = reader.ReadBoolean();
        }
    }
}