namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    using Types.Game.Look;
    using Utils.IO;

    public class GameContextRefreshEntityLookMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5637;
        public override ushort MessageID => ProtocolId;
        public double ObjectId { get; set; }
        public EntityLook Look { get; set; }

        public GameContextRefreshEntityLookMessage(double objectId, EntityLook look)
        {
            ObjectId = objectId;
            Look = look;
        }

        public GameContextRefreshEntityLookMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(ObjectId);
            Look.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadDouble();
            Look = new EntityLook();
            Look.Deserialize(reader);
        }

    }
}
