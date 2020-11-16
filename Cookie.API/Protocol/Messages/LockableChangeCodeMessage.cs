using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class LockableChangeCodeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5666;

        public override ushort MessageID => ProtocolId;

        public string Code { get; set; }
        public LockableChangeCodeMessage() { }

        public LockableChangeCodeMessage( string Code ){
            this.Code = Code;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Code);
        }

        public override void Deserialize(IDataReader reader)
        {
            Code = reader.ReadUTF();
        }
    }
}
