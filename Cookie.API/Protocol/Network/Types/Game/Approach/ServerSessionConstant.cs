using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Approach
{
    public class ServerSessionConstant : NetworkType
    {
        public const short ProtocolId = 430;

        public ServerSessionConstant()
        {
        }

        public ServerSessionConstant(ushort objectId)
        {
            ObjectID = objectId;
        }

        public override short TypeID => ProtocolId;

        public ushort ObjectID { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ObjectID);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectID = reader.ReadVarUhShort();
        }
    }
}