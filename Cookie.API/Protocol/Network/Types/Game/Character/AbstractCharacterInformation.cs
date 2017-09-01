using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Character
{
    public class AbstractCharacterInformation : NetworkType
    {
        public const ushort ProtocolId = 400;

        public AbstractCharacterInformation(ulong objectId)
        {
            ObjectId = objectId;
        }

        public AbstractCharacterInformation()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ulong ObjectId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUhLong();
        }
    }
}