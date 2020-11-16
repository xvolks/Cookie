using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DebugInClientMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6028;

        public override ushort MessageID => ProtocolId;

        public sbyte Level { get; set; }
        public string Message { get; set; }
        public DebugInClientMessage() { }

        public DebugInClientMessage( sbyte Level, string Message ){
            this.Level = Level;
            this.Message = Message;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Level);
            writer.WriteUTF(Message);
        }

        public override void Deserialize(IDataReader reader)
        {
            Level = reader.ReadSByte();
            Message = reader.ReadUTF();
        }
    }
}
