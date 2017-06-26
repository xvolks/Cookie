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

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarUhShort(ObjectID);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ObjectID = reader.ReadVarUhShort();
        }
    }
}