using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class StatsPreset : Preset
    {
        public new const short ProtocolId = 521;
        public override short TypeId { get { return ProtocolId; } }

        public List<SimpleCharacterCharacteristicForPreset> Stats;

        public StatsPreset(): base()
        {
        }

        public StatsPreset(
            short id_,
            List<SimpleCharacterCharacteristicForPreset> stats
        ): base(
            id_
        )
        {
            Stats = stats;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)Stats.Count());
            foreach (var current in Stats)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countStats = reader.ReadShort();
            Stats = new List<SimpleCharacterCharacteristicForPreset>();
            for (short i = 0; i < countStats; i++)
            {
                SimpleCharacterCharacteristicForPreset type = new SimpleCharacterCharacteristicForPreset();
                type.Deserialize(reader);
                Stats.Add(type);
            }
        }
    }
}