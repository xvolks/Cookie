using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GameFightFighterInformations : GameContextActorInformations
    {
        public new const ushort ProtocolId = 143;

        public override ushort TypeID => ProtocolId;

        public sbyte TeamId { get; set; }
        public sbyte Wave { get; set; }
        public bool Alive { get; set; }
        public GameFightMinimalStats Stats { get; set; }
        public List<short> PreviousPositions { get; set; }
        public GameFightFighterInformations() { }

        public GameFightFighterInformations( sbyte TeamId, sbyte Wave, bool Alive, GameFightMinimalStats Stats, List<short> PreviousPositions ){
            this.TeamId = TeamId;
            this.Wave = Wave;
            this.Alive = Alive;
            this.Stats = Stats;
            this.PreviousPositions = PreviousPositions;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(TeamId);
            writer.WriteSByte(Wave);
            writer.WriteBoolean(Alive);
            Stats.Serialize(writer);
			writer.WriteShort((short)PreviousPositions.Count);
			foreach (var x in PreviousPositions)
			{
				writer.WriteVarShort(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TeamId = reader.ReadSByte();
            Wave = reader.ReadSByte();
            Alive = reader.ReadBoolean();
            Stats = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Stats.Deserialize(reader);
            var PreviousPositionsCount = reader.ReadShort();
            PreviousPositions = new List<short>();
            for (var i = 0; i < PreviousPositionsCount; i++)
            {
                PreviousPositions.Add(reader.ReadVarShort());
            }
        }
    }
}
