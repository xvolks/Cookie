namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    using Types.Game.Friend;
    using Utils.IO;

    public class IgnoredAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5678;
        public override ushort MessageID => ProtocolId;
        public IgnoredInformations IgnoreAdded { get; set; }
        public bool Session { get; set; }

        public IgnoredAddedMessage(IgnoredInformations ignoreAdded, bool session)
        {
            IgnoreAdded = ignoreAdded;
            Session = session;
        }

        public IgnoredAddedMessage() { }

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
