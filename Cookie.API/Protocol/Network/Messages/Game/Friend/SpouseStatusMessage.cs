using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    public class SpouseStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6265;

        public SpouseStatusMessage(bool hasSpouse)
        {
            HasSpouse = hasSpouse;
        }

        public SpouseStatusMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool HasSpouse { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(HasSpouse);
        }

        public override void Deserialize(IDataReader reader)
        {
            HasSpouse = reader.ReadBoolean();
        }
    }
}