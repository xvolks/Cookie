using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GuildInAllianceInformations : GuildInformations
    {
        public new const ushort ProtocolId = 420;

        public override ushort TypeID => ProtocolId;

        public byte NbMembers { get; set; }
        public int JoinDate { get; set; }
        public GuildInAllianceInformations() { }

        public GuildInAllianceInformations( byte NbMembers, int JoinDate ){
            this.NbMembers = NbMembers;
            this.JoinDate = JoinDate;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(NbMembers);
            writer.WriteInt(JoinDate);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            NbMembers = reader.ReadByte();
            JoinDate = reader.ReadInt();
        }
    }
}
