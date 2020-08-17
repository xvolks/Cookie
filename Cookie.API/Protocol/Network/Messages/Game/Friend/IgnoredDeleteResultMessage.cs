using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    public class IgnoredDeleteResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5677;

        public IgnoredDeleteResultMessage(bool success, bool session, string name)
        {
            Success = success;
            Session = session;
            Name = name;
        }

        public IgnoredDeleteResultMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Success { get; set; }
        public bool Session { get; set; }
        public string Name { get; set; }

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
            Success = BooleanByteWrapper.GetFlag(flag, 0);
            Session = BooleanByteWrapper.GetFlag(flag, 1);
            Name = reader.ReadUTF();
        }
    }
}