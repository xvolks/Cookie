using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameContextCreateMessage : NetworkMessage
    {
        public const uint ProtocolId = 200;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Context = 1;

        public GameContextCreateMessage()
        {
        }

        public GameContextCreateMessage(
            byte context
        )
        {
            Context = context;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Context);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Context = reader.ReadByte();
        }
    }
}