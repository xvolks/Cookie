namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Houses
{
    using Messages.Game.Context.Roleplay.Lockable;
    using Utils.IO;

    public class HouseLockFromInsideRequestMessage : LockableChangeCodeMessage
    {
        public new const ushort ProtocolId = 5885;
        public override ushort MessageID => ProtocolId;

        public HouseLockFromInsideRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }

    }
}
