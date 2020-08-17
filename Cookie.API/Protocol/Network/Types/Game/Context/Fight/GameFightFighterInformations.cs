using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class GameFightFighterInformations : GameContextActorInformations
    {
        public new const ushort ProtocolId = 143;

        public GameFightFighterInformations(byte teamId, byte wave, bool alive, GameFightMinimalStats stats,
            List<ushort> previousPositions)
        {
            TeamId = teamId;
            Wave = wave;
            Alive = alive;
            Stats = stats;
            PreviousPositions = previousPositions;
        }

        public GameFightFighterInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte TeamId { get; set; }
        public byte Wave { get; set; }
        public bool Alive { get; set; }
        public GameFightMinimalStats Stats { get; set; }
        public List<ushort> PreviousPositions { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(TeamId);
            writer.WriteByte(Wave);
            writer.WriteBoolean(Alive);
            writer.WriteUShort(Stats.TypeID);
            Stats.Serialize(writer);
            writer.WriteShort((short) PreviousPositions.Count);
            for (var previousPositionsIndex = 0;
                previousPositionsIndex < PreviousPositions.Count;
                previousPositionsIndex++)
                writer.WriteVarUhShort(PreviousPositions[previousPositionsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TeamId = reader.ReadByte();
            Wave = reader.ReadByte();
            Alive = reader.ReadBoolean();
            Stats = ProtocolTypeManager.GetInstance<GameFightMinimalStats>(reader.ReadUShort());
            Stats.Deserialize(reader);
            var previousPositionsCount = reader.ReadUShort();
            PreviousPositions = new List<ushort>();
            for (var previousPositionsIndex = 0;
                previousPositionsIndex < previousPositionsCount;
                previousPositionsIndex++)
                PreviousPositions.Add(reader.ReadVarUhShort());
        }
    }
}