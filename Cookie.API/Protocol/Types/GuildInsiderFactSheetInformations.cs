using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GuildInsiderFactSheetInformations : GuildFactSheetInformations
    {
        public new const ushort ProtocolId = 423;

        public override ushort TypeID => ProtocolId;

        public string LeaderName { get; set; }
        public ushort NbConnectedMembers { get; set; }
        public sbyte NbTaxCollectors { get; set; }
        public int LastActivity { get; set; }
        public GuildInsiderFactSheetInformations() { }

        public GuildInsiderFactSheetInformations( string LeaderName, ushort NbConnectedMembers, sbyte NbTaxCollectors, int LastActivity ){
            this.LeaderName = LeaderName;
            this.NbConnectedMembers = NbConnectedMembers;
            this.NbTaxCollectors = NbTaxCollectors;
            this.LastActivity = LastActivity;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(LeaderName);
            writer.WriteVarUhShort(NbConnectedMembers);
            writer.WriteSByte(NbTaxCollectors);
            writer.WriteInt(LastActivity);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            LeaderName = reader.ReadUTF();
            NbConnectedMembers = reader.ReadVarUhShort();
            NbTaxCollectors = reader.ReadSByte();
            LastActivity = reader.ReadInt();
        }
    }
}
