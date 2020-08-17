using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    public class FriendAddFailureMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5600;

        public FriendAddFailureMessage(byte reason)
        {
            Reason = reason;
        }

        public FriendAddFailureMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadByte();
        }
    }
}