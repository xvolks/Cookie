namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Houses
{
    using Utils.IO;

    public class HouseSellFromInsideRequestMessage : HouseSellRequestMessage
    {
        public new const ushort ProtocolId = 5884;
        public override ushort MessageID => ProtocolId;

        public HouseSellFromInsideRequestMessage() { }

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
