using Cookie.API.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Character
{
    public class AbstractCharacterInformation : NetworkType
    {
        public const short ProtocolId = 400;

        public AbstractCharacterInformation()
        {
        }

        public AbstractCharacterInformation(ulong objectId)
        {
            ObjectID = objectId;
        }

        public override short TypeID => ProtocolId;

        public ulong ObjectID { get; set; }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarUhLong(ObjectID);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ObjectID = reader.ReadVarUhLong();
        }
    }
}