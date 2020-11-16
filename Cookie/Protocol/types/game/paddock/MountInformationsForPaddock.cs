using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class MountInformationsForPaddock : NetworkType
    {
        public const short ProtocolId = 184;
        public override short TypeId { get { return ProtocolId; } }

        public short ModelId = 0;
        public string Name;
        public string OwnerName;

        public MountInformationsForPaddock()
        {
        }

        public MountInformationsForPaddock(
            short modelId,
            string name,
            string ownerName
        )
        {
            ModelId = modelId;
            Name = name;
            OwnerName = ownerName;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(ModelId);
            writer.WriteUTF(Name);
            writer.WriteUTF(OwnerName);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ModelId = reader.ReadVarShort();
            Name = reader.ReadUTF();
            OwnerName = reader.ReadUTF();
        }
    }
}