using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AcquaintanceSearchMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6144;

        public override ushort MessageID => ProtocolId;

        public string Nickname { get; set; }
        public AcquaintanceSearchMessage() { }

        public AcquaintanceSearchMessage( string Nickname ){
            this.Nickname = Nickname;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Nickname);
        }

        public override void Deserialize(IDataReader reader)
        {
            Nickname = reader.ReadUTF();
        }
    }
}
