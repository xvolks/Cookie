using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Connection.Register
{
    public class NicknameChoiceRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5639;

        public NicknameChoiceRequestMessage(string nickname)
        {
            Nickname = nickname;
        }

        public NicknameChoiceRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string Nickname { get; set; }

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