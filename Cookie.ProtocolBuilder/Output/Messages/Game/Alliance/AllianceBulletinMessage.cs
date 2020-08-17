namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    using Messages.Game.Social;
    using Utils.IO;

    public class AllianceBulletinMessage : BulletinMessage
    {
        public new const ushort ProtocolId = 6690;
        public override ushort MessageID => ProtocolId;

        public AllianceBulletinMessage() { }

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
