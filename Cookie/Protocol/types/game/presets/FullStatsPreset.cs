using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class FullStatsPreset : Preset
    {
        public new const short ProtocolId = 532;
        public override short TypeId { get { return ProtocolId; } }

        public List<CharacterCharacteristicForPreset> Stats;

        public FullStatsPreset(): base()
        {
        }

        public FullStatsPreset(
            short id_,
            List<CharacterCharacteristicForPreset> stats
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
            Stats = new List<CharacterCharacteristicForPreset>();
            for (short i = 0; i < countStats; i++)
            {
                CharacterCharacteristicForPreset type = new CharacterCharacteristicForPreset();
                type.Deserialize(reader);
                Stats.Add(type);
            }
        }
    }
}