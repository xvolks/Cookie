using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class InteractiveUseWithParamRequestMessage : InteractiveUseRequestMessage
    {
        public new const uint ProtocolId = 6715;
        public override uint MessageID { get { return ProtocolId; } }

        public int Id_ = 0;

        public InteractiveUseWithParamRequestMessage(): base()
        {
        }

        public InteractiveUseWithParamRequestMessage(
            int elemId,
            int skillInstanceUid,
            int id_
        ): base(
            elemId,
            skillInstanceUid
        )
        {
            Id_ = id_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteInt(Id_);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Id_ = reader.ReadInt();
        }
    }
}