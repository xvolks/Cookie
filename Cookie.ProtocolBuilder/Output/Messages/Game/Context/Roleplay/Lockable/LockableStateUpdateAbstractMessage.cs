namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Lockable
{
    using Utils.IO;

    public class LockableStateUpdateAbstractMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5671;
        public override ushort MessageID => ProtocolId;
        public bool Locked { get; set; }

        public LockableStateUpdateAbstractMessage(bool locked)
        {
            Locked = locked;
        }

        public LockableStateUpdateAbstractMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Locked);
        }

        public override void Deserialize(IDataReader reader)
        {
            Locked = reader.ReadBoolean();
        }

    }
}
