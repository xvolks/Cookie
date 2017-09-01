namespace Cookie.API.Protocol.Network.Messages.Game.Interactive.Zaap
{
    using Utils.IO;

    public class ZaapRespawnSaveRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6572;
        public override ushort MessageID => ProtocolId;

        public ZaapRespawnSaveRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
