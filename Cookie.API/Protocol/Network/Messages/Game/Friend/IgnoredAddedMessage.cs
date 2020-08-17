using Cookie.API.Protocol.Network.Types.Game.Friend;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    public class IgnoredAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5678;

        public IgnoredAddedMessage(IgnoredInformations ignoreAdded, bool session)
        {
            IgnoreAdded = ignoreAdded;
            Session = session;
        }

        public IgnoredAddedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public IgnoredInformations IgnoreAdded { get; set; }
        public bool Session { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort(IgnoreAdded.TypeID);
            IgnoreAdded.Serialize(writer);
            writer.WriteBoolean(Session);
        }

        public override void Deserialize(IDataReader reader)
        {
            IgnoreAdded = ProtocolTypeManager.GetInstance<IgnoredInformations>(reader.ReadUShort());
            IgnoreAdded.Deserialize(reader);
            Session = reader.ReadBoolean();
        }
    }
}