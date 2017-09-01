using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Paddock
{
    public class MountInformationsForPaddock : NetworkType
    {
        public const ushort ProtocolId = 184;

        public MountInformationsForPaddock(ushort modelId, string name, string ownerName)
        {
            ModelId = modelId;
            Name = name;
            OwnerName = ownerName;
        }

        public MountInformationsForPaddock()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort ModelId { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ModelId);
            writer.WriteUTF(Name);
            writer.WriteUTF(OwnerName);
        }

        public override void Deserialize(IDataReader reader)
        {
            ModelId = reader.ReadVarUhShort();
            Name = reader.ReadUTF();
            OwnerName = reader.ReadUTF();
        }
    }
}