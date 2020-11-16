using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionAcknowledgementMessage : NetworkMessage
    {
        public const uint ProtocolId = 957;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Valid = false;
        public byte ActionId = 0;

        public GameActionAcknowledgementMessage()
        {
        }

        public GameActionAcknowledgementMessage(
            bool valid,
            byte actionId
        )
        {
            Valid = valid;
            ActionId = actionId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Valid);
            writer.WriteByte(ActionId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Valid = reader.ReadBoolean();
            ActionId = reader.ReadByte();
        }
    }
}