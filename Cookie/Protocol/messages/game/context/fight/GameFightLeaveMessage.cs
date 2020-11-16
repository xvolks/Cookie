using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightLeaveMessage : NetworkMessage
    {
        public const uint ProtocolId = 721;
        public override uint MessageID { get { return ProtocolId; } }

        public double CharId = 0;

        public GameFightLeaveMessage()
        {
        }

        public GameFightLeaveMessage(
            double charId
        )
        {
            CharId = charId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(CharId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CharId = reader.ReadDouble();
        }
    }
}