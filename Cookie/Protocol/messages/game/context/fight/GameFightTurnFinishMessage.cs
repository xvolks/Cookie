using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightTurnFinishMessage : NetworkMessage
    {
        public const uint ProtocolId = 718;
        public override uint MessageID { get { return ProtocolId; } }

        public bool IsAfk = false;

        public GameFightTurnFinishMessage()
        {
        }

        public GameFightTurnFinishMessage(
            bool isAfk
        )
        {
            IsAfk = isAfk;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(IsAfk);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            IsAfk = reader.ReadBoolean();
        }
    }
}