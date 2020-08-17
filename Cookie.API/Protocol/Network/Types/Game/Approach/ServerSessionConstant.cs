using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Approach
{
    public class ServerSessionConstant : NetworkType
    {
        public const ushort ProtocolId = 430;

        public ServerSessionConstant(ushort objectId)
        {
            ObjectId = objectId;
        }

        public ServerSessionConstant()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort ObjectId { get; set; }

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