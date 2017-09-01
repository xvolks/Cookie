namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    using Utils.IO;

    public class MountInformationRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5972;
        public override ushort MessageID => ProtocolId;
        public double ObjectId { get; set; }
        public double Time { get; set; }

        public MountInformationRequestMessage(double objectId, double time)
        {
            ObjectId = objectId;
            Time = time;
        }

        public MountInformationRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(ObjectId);
            writer.WriteDouble(Time);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadDouble();
            Time = reader.ReadDouble();
        }

    }
}
