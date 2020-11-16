using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class FightResultPlayerListEntry : FightResultFighterListEntry
    {
        public new const short ProtocolId = 24;
        public override short TypeId { get { return ProtocolId; } }

        public short Level = 0;
        public List<FightResultAdditionalData> Additional;

        public FightResultPlayerListEntry(): base()
        {
        }

        public FightResultPlayerListEntry(
            short outcome,
            byte wave,
            FightLoot rewards,
            double id_,
            bool alive,
            short level,
            List<FightResultAdditionalData> additional
        ): base(
            outcome,
            wave,
            rewards,
            id_,
            alive
        )
        {
            Level = level;
            Additional = additional;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(Level);
            writer.WriteShort((short)Additional.Count());
            foreach (var current in Additional)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Level = reader.ReadVarShort();
            var countAdditional = reader.ReadShort();
            Additional = new List<FightResultAdditionalData>();
            for (short i = 0; i < countAdditional; i++)
            {
                var additionaltypeId = reader.ReadShort();
                FightResultAdditionalData type = new FightResultAdditionalData();
                type.Deserialize(reader);
                Additional.Add(type);
            }
        }
    }
}