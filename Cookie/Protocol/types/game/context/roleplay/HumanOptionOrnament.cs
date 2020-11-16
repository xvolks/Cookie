using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class HumanOptionOrnament : HumanOption
    {
        public new const short ProtocolId = 411;
        public override short TypeId { get { return ProtocolId; } }

        public short OrnamentId = 0;
        public short Level = 0;
        public short LeagueId = 0;
        public int LadderPosition = 0;

        public HumanOptionOrnament(): base()
        {
        }

        public HumanOptionOrnament(
            short ornamentId,
            short level,
            short leagueId,
            int ladderPosition
        ): base()
        {
            OrnamentId = ornamentId;
            Level = level;
            LeagueId = leagueId;
            LadderPosition = ladderPosition;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(OrnamentId);
            writer.WriteVarShort(Level);
            writer.WriteVarShort(LeagueId);
            writer.WriteInt(LadderPosition);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            OrnamentId = reader.ReadVarShort();
            Level = reader.ReadVarShort();
            LeagueId = reader.ReadVarShort();
            LadderPosition = reader.ReadInt();
        }
    }
}