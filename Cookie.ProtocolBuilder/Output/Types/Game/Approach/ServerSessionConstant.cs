namespace Cookie.API.Protocol.Network.Types.Game.Approach
{
    using Utils.IO;

    public class ServerSessionConstant : NetworkType
    {
        public const ushort ProtocolId = 430;
        public override ushort TypeID => ProtocolId;
        public ushort ObjectId { get; set; }

        public ServerSessionConstant(ushort objectId)
        {
            ObjectId = objectId;
        }

        public ServerSessionConstant() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUhShort();
        }

    }
}
