using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class EntityInformation : NetworkType
    {
        public const ushort ProtocolId = 546;

        public override ushort TypeID => ProtocolId;

        public ushort Id { get; set; }
        public uint Experience { get; set; }
        public bool Status { get; set; }
        public EntityInformation() { }

        public EntityInformation( ushort Id, uint Experience, bool Status ){
            this.Id = Id;
            this.Experience = Experience;
            this.Status = Status;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(Id);
            writer.WriteVarUhInt(Experience);
            writer.WriteBoolean(Status);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadVarUhShort();
            Experience = reader.ReadVarUhInt();
            Status = reader.ReadBoolean();
        }
    }
}
