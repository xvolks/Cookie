using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class HouseKickRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5698;
        public override uint MessageID { get { return ProtocolId; } }

        public long Id_ = 0;

        public HouseKickRequestMessage()
        {
        }

        public HouseKickRequestMessage(
            long id_
        )
        {
            Id_ = id_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(Id_);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadVarLong();
        }
    }
}