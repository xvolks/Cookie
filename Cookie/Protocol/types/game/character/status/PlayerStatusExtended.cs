using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class PlayerStatusExtended : PlayerStatus
    {
        public new const short ProtocolId = 414;
        public override short TypeId { get { return ProtocolId; } }

        public string Message;

        public PlayerStatusExtended(): base()
        {
        }

        public PlayerStatusExtended(
            byte statusId,
            string message
        ): base(
            statusId
        )
        {
            Message = message;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Message);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Message = reader.ReadUTF();
        }
    }
}