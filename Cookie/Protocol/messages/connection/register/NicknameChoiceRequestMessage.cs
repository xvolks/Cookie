using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class NicknameChoiceRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5639;
        public override uint MessageID { get { return ProtocolId; } }

        public string Nickname;

        public NicknameChoiceRequestMessage()
        {
        }

        public NicknameChoiceRequestMessage(
            string nickname
        )
        {
            Nickname = nickname;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Nickname);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Nickname = reader.ReadUTF();
        }
    }
}