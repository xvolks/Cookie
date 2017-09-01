using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    public class IgnoredAddRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5673;

        public IgnoredAddRequestMessage(string name, bool session)
        {
            Name = name;
            Session = session;
        }

        public IgnoredAddRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string Name { get; set; }
        public bool Session { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
            writer.WriteBoolean(Session);
        }

        public override void Deserialize(IDataReader reader)
        {
            Name = reader.ReadUTF();
            Session = reader.ReadBoolean();
        }
    }
}