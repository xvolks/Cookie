using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class HumanOptionOrnament : HumanOption
    {
        public new const ushort ProtocolId = 411;

        public override ushort TypeID => ProtocolId;

        public ushort OrnamentId { get; set; }
        public ushort Level { get; set; }
        public short LeagueId { get; set; }
        public int LadderPosition { get; set; }
        public HumanOptionOrnament() { }

        public HumanOptionOrnament( ushort OrnamentId, ushort Level, short LeagueId, int LadderPosition ){
            this.OrnamentId = OrnamentId;
            this.Level = Level;
            this.LeagueId = LeagueId;
            this.LadderPosition = LadderPosition;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(OrnamentId);
            writer.WriteVarUhShort(Level);
            writer.WriteVarShort(LeagueId);
            writer.WriteInt(LadderPosition);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            OrnamentId = reader.ReadVarUhShort();
            Level = reader.ReadVarUhShort();
            LeagueId = reader.ReadVarShort();
            LadderPosition = reader.ReadInt();
        }
    }
}
