using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    public class PrismInfoJoinLeaveRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5844;

        public PrismInfoJoinLeaveRequestMessage(bool join)
        {
            Join = join;
        }

        public PrismInfoJoinLeaveRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Join { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Join);
        }

        public override void Deserialize(IDataReader reader)
        {
            Join = reader.ReadBoolean();
        }
    }
}