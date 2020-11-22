using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class NicknameChoiceRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5639;

        public override ushort MessageID => ProtocolId;

        public string Nickname { get; set; }
        public NicknameChoiceRequestMessage() { }

        public NicknameChoiceRequestMessage( string Nickname ){
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
