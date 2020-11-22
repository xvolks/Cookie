using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameContextRemoveElementMessage : NetworkMessage
    {
        public const uint ProtocolId = 251;
        public override uint MessageID { get { return ProtocolId; } }

        public double Id_ = 0;

        public GameContextRemoveElementMessage()
        {
        }

        public GameContextRemoveElementMessage(
            double id_
        )
        {
            Id_ = id_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(Id_);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadDouble();
        }
    }
}