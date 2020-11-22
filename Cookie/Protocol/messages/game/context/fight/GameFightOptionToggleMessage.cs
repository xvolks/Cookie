using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightOptionToggleMessage : NetworkMessage
    {
        public const uint ProtocolId = 707;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Option = 3;

        public GameFightOptionToggleMessage()
        {
        }

        public GameFightOptionToggleMessage(
            byte option
        )
        {
            Option = option;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Option);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Option = reader.ReadByte();
        }
    }
}