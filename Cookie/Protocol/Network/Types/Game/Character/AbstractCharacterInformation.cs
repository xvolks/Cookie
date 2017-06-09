using Cookie.IO;

namespace Cookie.Protocol.Network.Types.Game.Character
{
    public class AbstractCharacterInformation : NetworkType
    {
        public const short ProtocolId = 400;
        public override short TypeID { get { return ProtocolId; } }

        public ulong ObjectID { get; set; }

        public AbstractCharacterInformation() { }

        public AbstractCharacterInformation(ulong objectId)
        {
            ObjectID = objectId;
        }

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
