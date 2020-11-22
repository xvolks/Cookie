using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class AllianceVersatileInformations : NetworkType
    {
        public const ushort ProtocolId = 432;

        public override ushort TypeID => ProtocolId;

        public uint AllianceId { get; set; }
        public ushort NbGuilds { get; set; }
        public ushort NbMembers { get; set; }
        public ushort NbSubarea { get; set; }
        public AllianceVersatileInformations() { }

        public AllianceVersatileInformations( uint AllianceId, ushort NbGuilds, ushort NbMembers, ushort NbSubarea ){
            this.AllianceId = AllianceId;
            this.NbGuilds = NbGuilds;
            this.NbMembers = NbMembers;
            this.NbSubarea = NbSubarea;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(AllianceId);
            writer.WriteVarUhShort(NbGuilds);
            writer.WriteVarUhShort(NbMembers);
            writer.WriteVarUhShort(NbSubarea);
        }

        public override void Deserialize(IDataReader reader)
        {
            AllianceId = reader.ReadVarUhInt();
            NbGuilds = reader.ReadVarUhShort();
            NbMembers = reader.ReadVarUhShort();
            NbSubarea = reader.ReadVarUhShort();
        }
    }
}
