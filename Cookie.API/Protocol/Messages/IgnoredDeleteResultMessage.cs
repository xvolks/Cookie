using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class IgnoredDeleteResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5677;

        public override ushort MessageID => ProtocolId;

        public bool Success { get; set; }
        public bool Session { get; set; }
        public string Name { get; set; }
        public IgnoredDeleteResultMessage() { }

        public IgnoredDeleteResultMessage( bool Success, bool Session, string Name ){
            this.Success = Success;
            this.Session = Session;
            this.Name = Name;
        }

        public override void Serialize(IDataWriter writer)
        {
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, Success);
			flag = BooleanByteWrapper.SetFlag(1, flag, Session);
			writer.WriteByte(flag);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
			var flag = reader.ReadByte();
			Success = BooleanByteWrapper.GetFlag(flag, 0);;
			Session = BooleanByteWrapper.GetFlag(flag, 1);;
            Name = reader.ReadUTF();
        }
    }
}
