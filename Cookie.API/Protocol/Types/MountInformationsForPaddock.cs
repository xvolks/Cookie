using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class MountInformationsForPaddock : NetworkType
    {
        public const ushort ProtocolId = 184;

        public override ushort TypeID => ProtocolId;

        public ushort ModelId { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public MountInformationsForPaddock() { }

        public MountInformationsForPaddock( ushort ModelId, string Name, string OwnerName ){
            this.ModelId = ModelId;
            this.Name = Name;
            this.OwnerName = OwnerName;
        }

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
