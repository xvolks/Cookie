using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class GameFightFighterInformations : GameContextActorInformations
    {
        public new const short ProtocolId = 143;
        public override short TypeId { get { return ProtocolId; } }

        public byte TeamId = 2;
        public byte Wave = 0;
        public bool Alive = false;
        public GameFightMinimalStats Stats;
        public List<short> PreviousPositions;

        public GameFightFighterInformations(): base()
        {
        }

        public GameFightFighterInformations(
            double contextualId,
            EntityLook look,
            EntityDispositionInformations disposition,
            byte teamId,
            byte wave,
            bool alive,
            GameFightMinimalStats stats,
            List<short> previousPositions
        ): base(
            contextualId,
            look,
            disposition
        )
        {
            TeamId = teamId;
            Wave = wave;
            Alive = alive;
            Stats = stats;
            PreviousPositions = previousPositions;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(TeamId);
            writer.WriteByte(Wave);
            writer.WriteBoolean(Alive);
            writer.WriteShort(Stats.TypeId);
            Stats.Serialize(writer);
            writer.WriteShort((short)PreviousPositions.Count());
            foreach (var current in PreviousPositions)
            {
                writer.WriteVarShort(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            TeamId = reader.ReadByte();
            Wave = reader.ReadByte();
            Alive = reader.ReadBoolean();
            var statsTypeId = reader.ReadShort();
            Stats = new GameFightMinimalStats();
            Stats.Deserialize(reader);
            var countPreviousPositions = reader.ReadShort();
            PreviousPositions = new List<short>();
            for (short i = 0; i < countPreviousPositions; i++)
            {
                PreviousPositions.Add(reader.ReadVarShort());
            }
        }
    }
}